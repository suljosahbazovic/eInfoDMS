// JavaScrip source code for LogIn formu
var elementi = document.getElementsByTagName("input"); //vraca sve elemente input tagove sa forme Login
for (var i = 0; i < elementi.length; i++) {
    if (elementi[i].type != "submit")
        elementi[i].onblur = validateInput;
}

document.getElementById("clear").onclick = clear;

function validateInput(e) {
    var element = e.target;
    if (element == null)
        element = e;
    var valid = true;
    if (element.value == "")
        valid = false;
    else {
        switch (element.id) {
            case "username":
                if (element.value.length < 3)
                    valid = false;                    
                break;
            case "password":
                var regexLetter = /[a-zA-Z]/;
                var regexNumber = /[0-9]/;
                valid = regexLetter.test(element.value) && regexNumber.test(element.value);
                break;
            default:
        }
    }
    if (!valid)
        element.classList.add("error");
    else
        element.classList.remove("error");

    return valid;
}

function clear() {
    for (var i = 0; i < elementi.length; i++) {
        if (elementi[i].type != "submit") {
            elementi[i].value = "";
            elementi[i].classList.remove("error");
        }
    }
}

function validateForm() {
    var valid = true;
    for (var i = 0; i < elementi.length; i++) {
        if (elementi[i].type != "submit") {
            if (!validateInput(elementi[i])) {
                valid = false;
            }
        }
    }
    return valid;
}