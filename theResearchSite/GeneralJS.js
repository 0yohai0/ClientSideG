

//
var icon = document.getElementById("icon")
var icon1 = document.getElementById("top")
var icon2 = document.getElementById("middle")
var icon3 = document.getElementById("bottom")
var nav = document.getElementById('nav')
var follower = document.getElementById("follower")
var topMenu = document.querySelector(".horizontal-nav")
var logo = document.querySelector(".logo")
var register = document.getElementById("btRegister")
var out = document.getElementById("btLogOut")
var about = document.getElementById("about")

icon.addEventListener('click', function () {
    icon.classList.toggle('humburger-icon-black')
    icon1.classList.toggle('top')
    icon2.classList.toggle('middle')
    icon3.classList.toggle('bottom')
    nav.classList.toggle('show')
    follower.classList.toggle('slide')
    topMenu.classList.toggle('horizontal-nav-white')
    logo.classList.toggle('logo-black')
    register.classList.toggle('red-register')
    about.classList.toggle('about-red')
    out.classList.toggle('red-register')
});




//בדיקות לדף כניסה
var errorPassword = document.getElementById("lErrorPassword").innerHTML;

//שם משתמש
function checkUserNameLogIn() {
    document.getElementById("lErrorUserName").innerHTML = "";
    var userName = document.getElementById("txbUserName").value;
    if (userName.length < 5 || userName.length > 12) {
        document.getElementById("lErrorUserName").innerHTML = "שם משתמש לא תקין";
        return;
    }
    if (containUpperCase(userName)) {
        document.getElementById("lErrorUserName").innerHTML = "שם משתמש לא תקין";
        return;
    }

} function checkPasswordLogIn() {
    document.getElementById("lErrorPassword").innerHTML = "";
    var password = document.getElementById("txbPassword").value;
    if (password.length < 4 || password.length > 12) {
        document.getElementById("lErrorPassword").innerHTML = "ססמה לא תקינה";
        return;
    }
    if (!containsNumbers(password)) {
        document.getElementById("lErrorPassword").innerHTML = "ססמה לא תקינה";
        return;
    }
    if (!containUpperCase(password)) {
        document.getElementById("lErrorPassword").innerHTML = "ססמה לא תקינה";
        return;
    }
    if (!contain2NspecialCharachters(password)) {
        document.getElementById("lErrorPassword").innerHTML = "ססמה לא תקינה";
        return;
    }
    if (!IsConsecutive(password)) {
        document.getElementById("lErrorPassword").innerHTML = "ססמה לא תקינה";
        return;
    }
}
function containsNumbers(str) {
    return /[0-9]{2}/.test(str);
}
function containUpperCase(str) {
    return /[A-Z]/.test(str);
}
function contain2NspecialCharachters(str) {
    return /[!-/]{2}/.test(str);
}
//בדיקת חוזק ססמה
function IsConsecutive(str) {
    var numsInPassword = [];
    for (var i = 0; i < str.length - 1; i++) {
        for (var x = i; x < str.length  && parseInt(str[i]) != NaN; x++) {
            var currentNum = parseInt(str[i]);
            numsInPassword[i] = currentNum;
        }
        if (!consecutive(numsInPassword)) {
            return false;
        }
    }
    return true;
}

function consecutive(array) {
    var i = 0;
    while (array.length > 2 && i < array.length) {
        d = array[i+1] - array[i];
        if (Math.abs(d) == 1) {
            return false;
        }
        i++;
    }
    return true;
}
//async function returnAsync() {
//    await 5
//    window.location.replace("homePage.aspx");
//}

