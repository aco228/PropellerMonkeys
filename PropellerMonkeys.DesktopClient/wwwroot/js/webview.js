function webview() {
  this.webview = null;

  this.init = function () {
    this.webview = document.getElementById('webview');
    //this.webview.setUserAgent('Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/75.0.3770.100 Safari/537.36');
    this.webview.addEventListener('did-stop-loading', this.loadstop);

  };

  this.loadstop = function () {
    if (this.webview.getURL() === "https://partners.propellerads.com/#/app/auth") {
      this.webview.executeJavaScript("alert('radi! username=" + _username + " and password=" + _password+"');");
    }

  };

  this.init();
}