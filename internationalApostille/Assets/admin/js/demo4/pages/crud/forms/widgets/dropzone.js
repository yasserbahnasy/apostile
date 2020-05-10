"use strict";
// Class definition

var KTDropzoneDemo = function () {    
    // Private functions
    var demos = function () {
        // single file upload

        $("#kt_dropzone_1").dropzone({
            url: "https://keenthemes.com/scripts/void.php",
            paramName: "file",
            maxFiles: 1,
            maxFilesize: 5,
            addRemoveLinks: !0,
            accept: function (e, o) {
                "justinbieber.jpg" == e.name ? o("Naha, you don't.") : o();
            }
        })
        
    }

    return {
        // public functions
        init: function() {
            demos(); 
        }
    };
}();

KTDropzoneDemo.init();