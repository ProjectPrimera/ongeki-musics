# ongeki-musics

## Development

```sh
docker run --rm -d --name ongeki-music-development-mariadb -p 33060:3306 -e MYSQL_ROOT_PASSWORD=password mariadb:10.4.13-bionic --character-set-server=utf8mb4 --collation-server=utf8mb4_bin
```
