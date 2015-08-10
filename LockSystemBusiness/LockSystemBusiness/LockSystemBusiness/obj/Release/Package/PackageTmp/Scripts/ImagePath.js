function GetImgUploadPath() {
    var urlpath = "";
    var environ = window.location.host;
    if (environ.indexOf("localhost") != -1 || environ.indexOf("cfmdev1") != -1) {
        urlpath = "C:/Users/stevey/Documents/GitHub/LockSystemBusiness/LockSystemBusiness/Images/Upload.ashx";
    }
    else {
        urlpath = "/Images/Upload.ashx";
    }
    return urlpath;
}

function GetImgBrowsePath() {
    var urlpath = "";
    var environ = window.location.host;
    if (environ.indexOf("localhost") != -1 || environ.indexOf("cfmdev1") != -1) {
        urlpath = "C:\Users\stevey\Documents\GitHub\LockSystemBusiness\LockSystemBusiness\Images\FileBrowser.cshtml";
    }
    else {
        urlpath = "/FileBrowser/Index";
    }
    return urlpath;
}

function GetImgName(URL) {
    var fileName = URL.split('/');
    fileName = fileName[fileName.length - 1];
    return fileName
}