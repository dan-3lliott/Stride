(function ($) {
    "use strict";
    
    //detect if text is present, style accordingly
    
    $('.input100').each(function(){
        $(this).on('blur', function(){
            if($(this).val().trim() !== "") {
                $(this).addClass('has-val');
            }
            else {
                $(this).removeClass('has-val');
            }
        })
    });
    
    //validate input
    
    let input = $('.validate-input .input100');

    $('.validate-form').on('submit',function(){
        let check = true;

        for(let i=0; i<input.length; i++) {
            if(validate(input[i]) === false){
                showValidate(input[i]);
                check=false;
            }
        }

        return check;
    });

    //if focused, hide validation notification
    
    $('.validate-form .input100').each(function(){
        $(this).focus(function(){
            hideValidate(this);
        });
    });

    function validate (input) {
        return ($(input).val().trim() !== '');
    }

    function showValidate(input) {
        let thisAlert = $(input).parent();
        $(thisAlert).addClass('alert-validate');
    }

    function hideValidate(input) {
        let thisAlert = $(input).parent();
        $(thisAlert).removeClass('alert-validate');
    }

})(jQuery);