window.CookieHandle = {
    getCookie: function (cookieName) {
        if (document.cookie.length > 0) {
            var c_start = document.cookie.indexOf(cookieName + "=");
            if (c_start !== -1) {
                c_start = c_start + cookieName.length + 1;
                var c_end = document.cookie.indexOf(";", c_start);
                if (c_end === -1) c_end = document.cookie.length;
                return decodeURIComponent(document.cookie.substring(c_start, c_end));
            }
        }
        return "";
    },
    setCookie: function (cookieName, value, expiredays) {
        var exdate = new Date();
        exdate.setDate(exdate.getDate() + expiredays);
        var expire_cookie = cookieName + "=" + decodeURI(value) + ";expires=" + exdate.toUTCString();
        document.cookie = expire_cookie;
    }
};