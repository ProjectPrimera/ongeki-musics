import {
    config, library, dom
} from './../../node_modules/@fortawesome/fontawesome-svg-core/index';
// import {
//     faCalendarAlt
// } from './../../node_modules/@fortawesome/free-regular-svg-icons/index';
import {
    faBars
} from './../../node_modules/@fortawesome/free-solid-svg-icons/index';
import {
    faTwitter, faGithub
} from './../../node_modules/@fortawesome/free-brands-svg-icons/index';
library.add(
    faBars,
    faTwitter, faGithub
);
config.showMissingIcons = true;

dom.watch();
