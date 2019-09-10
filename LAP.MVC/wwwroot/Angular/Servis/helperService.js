angular.module("HelperService", []).
    factory("helperSrv", function () {
        function notification(title, message, messageType) {
            toastr[messageType](title, message);
            toastr.options = {
                "closeButton": true,
                "debug": false,
                "progressBar": true,
                "preventDuplicates": false,
                "positionClass": "toast-top-right",
                "onclick": null,
                "showDuration": "400",
                "hideDuration": "1000",
                "timeOut": "7000",
                "extendedTimeOut": "1000",
                "showEasing": "swing",
                "hideEasing": "linear",
                "showMethod": "fadeIn",
                "hideMethod": "fadeOut"
            };
        }

        function jQFormSerializeArrToJson(formSerializeArr) {
            var jsonObj = {};
            jQuery.map(formSerializeArr, function (n, i) {
                jsonObj[n.name] = n.value;
            });

            return jsonObj;
        }
        function isNotEmpty(str) {
            return !(!str || 0 === str.length || 0 === str.trim().length);
        }
        return {
            notification: function (title, message, messageType) {
                notification(title, message, messageType);
            },
            convertFormJson: function (formSerializeArr) {
                return jQFormSerializeArrToJson(formSerializeArr);
            },
            isNotEmpty: function (str) {
                return isNotEmpty(str);
            }
        };
    });