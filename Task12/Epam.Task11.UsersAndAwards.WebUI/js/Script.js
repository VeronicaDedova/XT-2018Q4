function Redirect(path) { window.location = path; }

function Visible() {
    var firstName = document.getElementById("firstName").value;
    var lastName = document.getElementById("lastName").value;
    var patronymic = document.getElementById("patronymic").value;
    var dateOfBirth = document.getElementById("dateOfBirth").value;

    if (firstName.length != 0 && lastName.length != 0 && patronymic.length != 0 && dateOfBirth.length != 0) {
        document.getElementById("submit").style.visibility = 'visible';
    }
}