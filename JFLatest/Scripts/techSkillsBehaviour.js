$(document).ready(function () {
    var techskillrowCount = $('#techSkills').children('.row').length;

    //techSkillRows = $('#techSkills').children('.row').children('.col-md-6').children('.years-experience-dropdown').each(function () {
    //    this.disabled = "disabled";
    //})

    //for each row
    $('#techSkills').children('.row').each(function (index) {

        //for each div in the row


        techSkillDropdownColumn = this.getElementsByClassName('col-md-6')[0];
        techSkillDropdownExpColumn = this.getElementsByClassName('col-md-6')[1];
        techSkillDropdown = techSkillDropdownColumn.getElementsByClassName("form-control")[0];
        techSkillDropdownExp = techSkillDropdownExpColumn.getElementsByClassName('years-experience-dropdown')[0];
        techSkillRfvExp = document.getElementById("rfv_technical_skill_" + parseInt(index+1) + "_years_experience");
        if (techSkillDropdown.selectedIndex == 0) {
            techSkillDropdownExp.disabled = true;

        } else {
            if (isPostBack()) {
                ValidatorEnable(techSkillRfvExp, true);
            }
        }

    })
});



function yearsExpToggle(dropDown, index) {
    drpdTechSkillYearsExp = document.getElementById("drpd_technical_skill_" + index + "_years_experience");
    rfvTechSkillYearsExp = document.getElementById("rfv_technical_skill_" + index + "_years_experience");

    if ((dropDown.selectedIndex != 0)) {
        drpdTechSkillYearsExp.disabled = false;

    }
    else {
        drpdTechSkillYearsExp.selectedIndex = 0;
        drpdTechSkillYearsExp.disabled = true;
    }

    ValidatorEnable(rfvTechSkillYearsExp, !drpdTechSkillYearsExp.disabled);
    //document.write(document.getElementById("rfv_technical_skill_" + index + "_years_experience").id);
    //document.write(!yearsExpDropDown.disabled);
}


function isPostBack() { //function to check if page is a postback-ed one
    return document.getElementById('_ispostback').value == 'True';
}