const path = require('path');
const LicenseCheckerWebpackPlugin = require("license-checker-webpack-plugin");

module.exports = (env, argv) => {
    const isDevelopment = (argv.mode === 'development');
    return {
        entry: './Assets/TypeScript/entry.ts',
        mode: (isDevelopment ? 'development' : 'production'),
        devtool: (isDevelopment ? 'source-map' : ''),
        output: {
            filename: 'bundle.js',
            path: path.resolve(__dirname, 'wwwroot/static')
        },
        module: {
            rules: [
                {
                    test: /\.(sa|sc|c)ss$/,
                    use: [
                        'style-loader',
                        {
                            loader: 'css-loader',
                            options: {
                                url: false,
                                sourceMap: isDevelopment,
                                importLoaders: 2
                            },
                        },
                        {
                            loader: "postcss-loader",
                            options: {
                                sourceMap: isDevelopment,
                                plugins: [
                                    require("autoprefixer")({
                                        grid: true
                                    })
                                ]
                            }
                        },
                        {
                            loader: 'sass-loader',
                            options: {
                                sourceMap: isDevelopment,
                            }
                        }
                    ],
                },
                {
                    test: /\.ts$/,
                    use: [
                        { loader: "ts-loader" }
                    ]
                }
            ],
        },
        plugins: [
            new LicenseCheckerWebpackPlugin({
                allow: "(Apache-2.0 OR BSD-2-Clause OR BSD-3-Clause OR MIT OR CC-BY-4.0)",
                emitError: true,
                outputWriter: (dependencies) => {
                    return JSON.stringify(dependencies);
                },
                outputFilename: "third_party_notices.json"
            })
        ]
    };
};

