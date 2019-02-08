"use strict";

(function () {
    window.onload = function (){
        var $inputs = $(".ServerRequest");

        $inputs.click(function (event) {
            event.preventDefault();
            var idInput = this.getAttribute("id");

            if (idInput == 'ShowAllUsers') {
                $.ajax({
                    method: "POST",
                    url: "Logic.cshtml",
                    data: { action: idInput },
                    success: function (responce) {
                        Output.innerHTML = responce;
                    }
                })
            }

            if (idInput == 'AddUser') {
                var userId = $('#AddUserForm .UserId').val();
                var userName = $('#AddUserForm .UserName').val();
                var userBirthDate = $('#AddUserForm .UserBirthDate').val();
                $.ajax({
                    method: "POST",
                    url: "Logic.cshtml",
                    data: { action: idInput, id: userId, name: userName, birthDate: userBirthDate },
                    success: function (responce) {
                        Output.innerHTML = responce;
                    }
                })
            }

            if (idInput == 'DeleteUser') {
                var userId = $('#DeleteUserForm .UserId').val();
                $.ajax({
                    method: "POST",
                    url: "Logic.cshtml",
                    data: { action: idInput, id: userId},
                    success: function (responce) {
                        Output.innerHTML = responce;
                    }
                })
            }

            if (idInput == 'ShowAllAwards') {
                $.ajax({
                    method: "POST",
                    url: "Logic.cshtml",
                    data: { action: idInput},
                    success: function (responce) {
                        Output.innerHTML = responce;
                    }
                })
            }

            if (idInput == 'ShowAllAwardsAndUsers') {
                $.ajax({
                    method: "POST",
                    url: "Logic.cshtml",
                    data: { action: idInput },
                    success: function (responce) {
                        Output.innerHTML = responce;
                    }
                })
            }

            if (idInput == 'AddAward') {
                var awardId = $('#AddAwardForm .AwardId').val();
                var awardTitle = $('#AddAwardForm .AwardTitle').val();
                $.ajax({
                    method: "POST",
                    url: "Logic.cshtml",
                    data: { action: idInput, id: awardId, title: awardTitle },
                    success: function (responce) {
                        Output.innerHTML = responce;
                    }
                })
            }

            if (idInput == 'DeleteAward') {
                awardId = $('#DeleteAwardForm .AwardId').val();
                $.ajax({
                    method: "POST",
                    url: "Logic.cshtml",
                    data: { action: idInput, id: awardId},
                    success: function (responce) {
                        Output.innerHTML = responce;
                    }
                })
            }

            if (idInput == 'AddAwardToUser') {
                awardId = $('#AddAwardToUserForm .AwardId').val();
                userId = $('#AddAwardToUserForm .UserId').val();
                $.ajax({
                    method: "POST",
                    url: "Logic.cshtml",
                    data: { action: idInput, idA: awardId, idU: userId },
                    success: function (responce) {
                        Output.innerHTML = responce;
                    }
                })
            }

            if (idInput == 'DeleteUserAward') {
                awardId = $('#DeleteUserAwardForm .AwardId').val();
                userId = $('#DeleteUserAwardForm .UserId').val();
                $.ajax({
                    method: "POST",
                    url: "Logic.cshtml",
                    data: { action: idInput, idA: awardId, idU: userId },
                    success: function (responce) {
                        Output.innerHTML = responce;
                    }
                })
            }

        })
            
        //$('#ShowAllUsers').submit(function (event) {
        //    event.preventDefault();
        //    $.ajax({
        //        method: "POST",
        //        url: "Logic.cshtml",
        //        data: { action: "ShowAllUsers" },
        //        success: function (responce) {
        //            Output.innerHTML = responce;
        //        }
        //    })
        //})

        //$('#AddUser').submit(function (event) {
        //    var userId = $('#AddUser .UserId').val();
        //    var userName = $('#AddUser .UserName').val();
        //    var userBirthDate = $('#AddUser .UserBirthDate').val();
        //    event.preventDefault();
        //    $.ajax({
        //        method: "POST",
        //        url: "Logic.cshtml",
        //        data: { action: "AddUse", id: userId, name: userName, birthDate: userBirthDate },
        //        success: function (responce) {
        //            Output.innerHTML = responce;
        //        }
        //    })
        //})

       
    }

})();
