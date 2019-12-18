
(function ($) {
    "use strict";
    
    //hide validate alert if element is focused
    
    $('.validate-form .input100').each(function(){
        $(this).focus(function(){
            hideValidate(this);
        });
    });

    //validate
    
    function validate (input) {
        if($(input).val().trim() == '') {
            return false;
        }
    }

    //show validation alert
    
    function showValidate(input) {
        var thisAlert = $(input).parent();
        $(thisAlert).addClass('alert-validate');
    }

    //hide validation alert
    
    function hideValidate(input) {
        var thisAlert = $(input).parent();
        $(thisAlert).removeClass('alert-validate');
    }

})(jQuery);