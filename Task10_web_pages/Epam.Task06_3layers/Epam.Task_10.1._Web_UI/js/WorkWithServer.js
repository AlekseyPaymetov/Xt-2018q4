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

            if (idInput == 'ChangeUser') {
                var oldUserId = $('#ChangeUserForm .OldUserId').val();
                userId = $('#ChangeUserForm .UserId').val();
                userName = $('#ChangeUserForm .UserName').val();
                userBirthDate = $('#ChangeUserForm .UserBirthDate').val();

                $.ajax({
                    method: "POST",
                    url: "Logic.cshtml",
                    data: { action: idInput, oldId: oldUserId, id: userId, name: userName, birthDate: userBirthDate },
                    success: function (responce) {
                        Output.innerHTML = responce;
                    }
                })
            }

            if (idInput == 'ChangeAward') {
                var oldAwardId = $('#ChangeAwardForm .OldAwardId').val();
                awardId = $('#ChangeAwardForm .AwardId').val();
                awardTitle = $('#ChangeAwardForm .AwardTitle').val();
                
                $.ajax({
                    method: "POST",
                    url: "Logic.cshtml",
                    data: { action: idInput, oldId: oldAwardId, id: awardId, title: awardTitle},
                    success: function (responce) {
                        Output.innerHTML = responce;
                    }
                })
            }

            if (idInput == 'ChangeUserAward') {
                oldUserId = $('#ChangeUserAwardForm .OldUserId').val();
                oldAwardId = $('#ChangeUserAwardForm .OldAwardId').val();
                awardId = $('#ChangeUserAwardForm .AwardId').val();
                userId = $('#ChangeUserAwardForm .UserId').val();

                $.ajax({
                    method: "POST",
                    url: "Logic.cshtml",
                    data: { action: idInput, 'oldUserId': oldUserId, 'oldAwardId': oldAwardId, 'awardId': awardId, 'userId': userId },
                    success: function (responce) {
                        Output.innerHTML = responce;
                    }
                })
            }

            if(idInput == 'DeleteUserAward_v2') {
                var answer = confirm("Delete this award from all users?");
                if (answer) {
                    awardId = $('#DeleteUserAwardForm_v2 .AwardId').val();
                    userId = $('#DeleteUserAwardForm_v2 .UserId').val();
                    $.ajax({
                        method: "POST",
                        url: "Logic.cshtml",
                        data: { action: idInput, idA: awardId, idU: userId },
                        success: function (responce) {
                            Output.innerHTML = responce;
                        }
                    })
                }
                
            }
            
        })
       
    }

})();
