function logJSONData() {
    const login = document.getElementById("login");
    login.addEventListener("click", function () {
        const res = fetch("https://localhost:7037/LogIn_API", {email: document.getElementById("email").value, password: document.getElementById("password").value});
        if (res.status == 200) {
            window.location.href="index.html";
            if (res.value == "true") {
                console.log("Login Successful");
                window.open("index.html");
            }
            else {
                
                console.log("Login Failed");
                // show error message
            }
        }
    });
}
window.onload = logJSONData;