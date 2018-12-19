$(function () {

    function getStepsData(formId) {
        var form = $("#" + formId),
            steps = form.find(".step"),
            stepNr,
            stepTitle,
            stepsData = [];

        $.each(steps, function (index, step) {
            var stepObj = {};

            stepObj.number = index + 1;
            stepObj.title = $(step).find("legend").text();

            stepsData.push(stepObj);
        });

        return stepsData;
    }


    function buildSteps(formId, data) {
        var form = $("#" + formId),
            wrapper = $("<ul class='form__steps'>"),
            step = "<li class='form__step'>",
            container;

        $.each(data, function (index, item) {
            container = $("<div class='form__step-container'>");
            container.append("<span class='form__step-nr'>" + item.number + "</span>");
            container.append("<span class='form__step-title'>" + item.title + "</span>");

            wrapper.append(step);

            if (index === 0) {
                wrapper.children(".form__step").addClass("is-active");
            }

            wrapper.children(".form__step:last-child").append(container);

            container = $("<div class='form__step-container'>");
        });

        form.before(wrapper);
    }


    function foldForm(formId) {
        var form = $("#" + formId),
            steps = form.find(".step");

        $.each(steps, function (index, step) {
            if (index === 0) {
                $(step).addClass("is-active");
            } else {
                $(step).hide();
            }
        });
    }


    function setVisibilityButtons(formId) {
        var form = $("#" + formId),
            steps = form.find(".step"),
            firstStep = $(steps[0]),
            lastStep = $(steps[steps.length - 1]),
            submitBtn = $(form.find("[type=submit]")),
            prevBtn = $(form.find(".js-prev")),
            nextBtn = $(form.find(".js-next"));

        if (firstStep.hasClass("is-active")) {
            submitBtn.hide();
            prevBtn.hide();
            nextBtn.show();
        } else if (lastStep.hasClass("is-active")) {
            submitBtn.show();
            prevBtn.show();
            nextBtn.hide();
        } else {
            submitBtn.hide();
            prevBtn.show();
            nextBtn.show();
        }
    }


    function nextStep(formId) {
        var form = $("#" + formId),
            currentStep = $(form.find(".step.is-active")),
            nextStep = currentStep.next(".step"),
            currentStepTop = $(form.prev().find(".form__step.is-active")),
            nextStepTop = currentStepTop.next(".form__step");

        currentStep.removeClass("is-active").hide();
        nextStep.addClass("is-active").show();
        currentStepTop.removeClass("is-active");
        nextStepTop.addClass("is-active");
    }


    function prevStep(formId) {
        var form = $("#" + formId),
            currentStep = $(form.find(".step.is-active")),
            prevStep = currentStep.prev(".step"),
            currentStepTop = $(form.prev().find(".form__step.is-active")),
            prevStepTop = currentStepTop.prev(".form__step");

        currentStep.removeClass("is-active").hide();
        prevStep.addClass("is-active").show();
        currentStepTop.removeClass("is-active");
        prevStepTop.addClass("is-active");
    }


    function initForms() {
        var steppedFormSelector = ".form--stepped",
            formId,
            stepsData;

        $(steppedFormSelector).each(function () {
            formId = $(this).attr("id");

            // Get the staps data -- step numbers and titles
            stepsData = getStepsData(formId);

            // Build the steps navigation
            buildSteps(formId, stepsData);

            // Hide all but the first steps
            foldForm(formId);

            // Show / hide relevant buttons
            setVisibilityButtons(formId);

        });
    };


    // Initialize form validation
    $(".validate").validate({
        errorPlacement: function (error, element) {
            error.insertBefore(element);
        },
        rules: {
            password: {
                required: true,
                minlength: 6,
                maxlength: 18

            },
            confirm: {
                required: true,
                equalTo: "#password",
                minlength: 6,
                maxlength: 18
            },
            egn: {
                required: true,
                egnValidation: true, 
            }

        //success: function (element) {
        //    if (element.parent().hasClass("checkboxes") || element.parent().hasClass("radiobuttons")) {
        //        $(element).remove();
        //    }
        }
    });


    // Initialize all stepped forms
    initForms();

    // Next Step
    $("body").on("click", ".js-next", function (event) {
        event.preventDefault();
        var formId = $(this).closest("form").attr("id"),
            isValid = $("#" + formId).valid();


        if (isValid) {
            nextStep(formId);
            setVisibilityButtons(formId);
        }


    });

    // Prev Step
    $("body").on("click", ".js-prev", function (event) {
        event.preventDefault();
        var formId = $(this).closest("form").attr("id");

        prevStep(formId);
        setVisibilityButtons(formId);
    });

    $.validator.addMethod("egnValidation", function (egn) {
        if (egn.length != 10)
            return false;
        if (/[^0-9]/.test(egn))
            return false;
        var year = Number(egn.slice(0, 2));
        var month = Number(egn.slice(2, 4));
        var day = Number(egn.slice(4, 6));

        if (month >= 40) {
            year += 2000;
            month -= 40;
        } else if (month >= 20) {
            year += 1800;
            month -= 20;
        } else {
            year += 1900;
        }

        if (!isValidDate(year, month, day))
            return false;

        var checkSum = 0;
        var weights = [2, 4, 8, 5, 10, 9, 7, 3, 6];

        for (var ii = 0; ii < weights.length; ++ii) {
            checkSum += weights[ii] * Number(egn.charAt(ii));
        }

        checkSum %= 11;
        checkSum %= 10;

        if (checkSum !== Number(egn.charAt(9)))
            return false;

        return true;
    }, "Not valid EGN number"); 


    function isValidDate(y, m, d) {
        var date = new Date(y, m - 1, d);
        return date && (date.getMonth() + 1) == m && date.getDate() == Number(d);
    } 
}); 