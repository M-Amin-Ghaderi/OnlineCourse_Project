let passwordCheckBox = document.getElementById("passwordChecked");
let confirmPasswordCheckBox = document.getElementById("confirmPasswordChecked");

let passwordInput = document.getElementById("password");
let confirmPasswordInput = document.getElementById("confirmPassword");

passwordCheckBox.addEventListener("change", () => {
    if (passwordCheckBox.checked) {
        passwordInput.type = "text";
    } else {
        passwordInput.type = "password"
    }
})

confirmPasswordCheckBox.addEventListener("change", () => {
    if (confirmPasswordCheckBox.checked) {
        confirmPasswordInput.type = "text";
    } else {
        confirmPasswordInput.type = "password"
    }
})


