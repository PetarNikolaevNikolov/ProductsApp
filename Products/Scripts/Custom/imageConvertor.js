function readFileAsBase64(fileUploadId, imgSelector) {
    if (document.getElementById(fileUploadId).value != "") {
        var file = document.getElementById(fileUploadId).files[0];
        var reader = new FileReader();
        reader.onload = function (evt) {
            try {
                var result = evt.target.result;
                var img = $(imgSelector);
                img.attr('src', result);
                img.attr('data-extension', getFileExtension(file.name));
            }
            finally {
                $("#circularG").hide();
            }

        }
        $("#circularG").show();
        reader.readAsDataURL(file);
    }
}