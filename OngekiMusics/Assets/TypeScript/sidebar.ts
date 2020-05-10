import * as M from "materialize-css";

document.addEventListener('DOMContentLoaded', () => {
    let sidenav = document.querySelectorAll('.sidenav');
    M.Sidenav.init(sidenav, {});

    let collapsible = document.querySelectorAll('.collapsible');
    M.Collapsible.init(collapsible, {});
});
