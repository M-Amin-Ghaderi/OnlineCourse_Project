let checkBox = document.getElementById("flexCheckChecked");
let passwordInput = document.getElementById("password");


CheckboxCheck()



checkBox.addEventListener("change", function () {
    CheckboxCheck();
});


function CheckboxCheck() {
    if (checkBox.checked) {
        passwordInput.type = "text";
    } else {
        passwordInput.type = "password";
    }
}