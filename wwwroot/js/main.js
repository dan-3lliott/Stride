﻿(function ($) {
    "use strict";
    
    //checks for value after user leaves field
    
    $('.input100').each(function(){
        $(this).on('blur', function(){
            if($(this).val()) {
                $(this).addClass('has-val');
            }
            else {
                $(this).removeClass('has-val');
            }
        });
    });
    
    //checks for value on page load, sets selected value for select boxes if present
    
    $(document).ready(function(){
        $('.select').each(function(){
            $(this).val($(this).attr('selectedval'));
        });
        $('.input100').each(function(){
            if ($(this).val()) {
                $(this).addClass('has-val');
            }
        });
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
        return ($(input).val());
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