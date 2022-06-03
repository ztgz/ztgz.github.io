export function getFromLocalStorage(key) {
    return window.localStorage.getItem(key);
}

export function setToLocalStorage(key, value) {
    window.localStorage.setItem(key, value);
}