JsonUrl = "http://localhost:8080/WebDeploy/";
//JsonUrl = "http://utsdp.cloudapp.net/WebDeploy/";

$(document).ready(function () {
    //Validate
    $('.input-group input[required], .input-group textarea[required], .input-group select[required]').on('keyup change', function() {
        var $form = $(this).closest('form'),
            $group = $(this).closest('.input-group'),
            $addon = $group.find('.input-group-addon'),
            $icon = $addon.find('span'),
            state = false;

        if (!$group.data('validate')) {
            state = $(this).val() ? true : false;
        } else if ($group.data('validate') == "email") {
            state = /^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$/.test($(this).val())
        } else if ($group.data('validate') == 'phone') {
            state = /^[(]{0,1}[0-9]{3}[)]{0,1}[-\s\.]{0,1}[0-9]{3}[-\s\.]{0,1}[0-9]{4}$/.test($(this).val())
        } else if ($group.data('validate') == "length") {
            state = $(this).val().length >= $group.data('length') ? true : false;
        } else if ($group.data('validate') == "number") {
            state = !isNaN(parseFloat($(this).val())) && isFinite($(this).val());
        }

        if (state) {
            $addon.removeClass('danger');
            $addon.addClass('success');
            $icon.attr('class', 'glyphicon glyphicon-ok');
        } else {
            $addon.removeClass('success');
            $addon.addClass('danger');
            $icon.attr('class', 'glyphicon glyphicon-remove');
        }

        if ($form.find('.input-group-addon.danger').length == 0) {
            $form.find('[type="submit"]').prop('disabled', false);
        } else {
            $form.find('[type="submit"]').prop('disabled', true);
        }
    });

    $('.input-group input[required], .input-group textarea[required], .input-group select[required]').trigger('change');


    //Sidebar
    var trigger = $('.hamburger'),
        overlay = $('.overlay'),
        isClosed = false;

    trigger.click(function() {
        hamburger_cross();
    });

    function hamburger_cross() {

        if (isClosed == true) {
            overlay.hide();
            trigger.removeClass('is-open');
            trigger.addClass('is-closed');
            isClosed = false;
        } else {
            overlay.show();
            trigger.removeClass('is-closed');
            trigger.addClass('is-open');
            isClosed = true;
        }
    }

    $('[data-toggle="offcanvas"]').click(function() {
        $('#wrapper').toggleClass('toggled');
    });

    $(".f_loading").html("<div class='text_c mal'><button class='btn btn-lg btn-primary m-progress'>Button</button></div>")

   
});



function api_ajax(getUrl, getAfter) {
    $.ajax({
        // Json_WorkshopWorkshopSets
        type: "Get",
        beforeSend: function (request) {
            request.setRequestHeader("AppKey", "123456");
            $(".f_loading").removeClass("none");
        },
        contentType: "application/json",
        url: JsonUrl + getUrl + getAfter,
        dataType: "json",
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            alert("Request: " + XMLHttpRequest.toString() + "\n\nStatus: " + textStatus + "\n\nError: " + errorThrown);
        },
        success: function (result) {
            console.log(result);
            ko.applyBindings({
                ko_array: result.Results
            });
            $('ul.f_load li').not(function (i) {
                return $(this).prevAll('li:has(a[data-workshopid="' + $('a', this).attr('data-workshopid') + '"])').length < 1;
            }).remove();
            $(".f_loading div").fadeOut(function () {
                $(".f_load").fadeIn();
            });
        }
    })
}

// Page:WorkshopList
$(document).ready(function () {
   

    //Page:Newsession
    $('#NewsessionModal').on('show.bs.modal', function (event) {
        var button = $(event.relatedTarget) // Button that triggered the modal
        var studentId = button.data('studentId')
        var BookingId = button.data('bookingid')
        var workshopid = button.data('workshopid')
        var studentID = button.data('studentID')
        var topic = button.data('topic')
        var description = button.data('description')
        var targetingGroup = button.data('targetingGroup')
        var campusID = button.data('campusID')
        var starting = button.data('starting')
        var ending = button.data('ending')
        var maximum = button.data('maximum')
        var cutoff = button.data('cutoff')
        var canceled = button.data('canceled')
        var attended = button.data('attended')
        var WorkShopSetID = button.data('WorkShopSetID')
        var type = button.data('type')
        var reminder_num = button.data('reminder_num')
        var reminder_sent = button.data('reminder_sent')
        var WorkshopArchived = button.data('WorkshopArchived')
        var BookingArchived = button.data('BookingArchived')
        var modal = $(this)
        modal.find('.json-BookingId').text(BookingId)
        modal.find('.json-workshopID').text(workshopid)
        modal.find('.json-studentID').text(studentID)
        modal.find('.json-topic').text(topic)
        modal.find('.json-description').text(description)
        modal.find('.json-targetingGroup').text(targetingGroup)
        modal.find('.json-campusID').text(campusID)
        modal.find('.json-starting').text(starting)
        modal.find('.json-ending').text(ending)
        modal.find('.json-maximum').text(maximum)
        modal.find('.json-cutoff').text(cutoff)
        modal.find('.json-canceled').text(canceled)
        modal.find('.json-attended').text(attended)
        modal.find('.json-WorkShopSetID').text(WorkShopSetID)
        modal.find('.json-type').text(type)
        modal.find('.json-reminder_num').text(reminder_num)
        modal.find('.json-reminder_sent').text(reminder_sent)
        modal.find('.json-WorkshopArchived').text(WorkshopArchived)
        modal.find('.json-BookingArchived').text(BookingArchived)
        f_reminderCreateHref = $("#f_reminderCreate").attr("href");
        $("#f_reminderCreate").attr("href", f_reminderCreateHref + "?workshopid=" + workshopid+"&bookingid="+BookingId);
        $("#WorkshopBookingCancel").attr("href", "javascript:api_WorkshopBookingCancel(" + workshopid + "," + studentid + "," + studentid + ")")
    })
});

//todo: Compile create & cancel in the future
function api_WorkshopBookingCreate(workshopId, studentId, userId) {
    $.ajax({
        type: "Post",
        beforeSend: function (request) {
            request.setRequestHeader("AppKey", "123456");
        },
        contentType: "application/json",
        url: JsonUrl+"api/workshop/booking/create?workshopId="+workshopId+"&studentId="+studentId+"&userId="+userId,
        dataType: "json",
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            alert("Request: " + XMLHttpRequest.toString() + "\n\nStatus: " + textStatus + "\n\nError: " + errorThrown);
        },
        success: function (result) {
            if (result.IsSuccess == true) {
                alert("Booking Success");
            }
        }
    })
}

function api_Student(studentId) {
    $.ajax({
        type: "Get",
        beforeSend: function (request) {
            request.setRequestHeader("AppKey", "123456");
            $(".f_loading").removeClass("none");
        },
        contentType: "application/json",
        url: JsonUrl + "api/student?id=" + studentId,
        dataType: 'json',
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            alert("Request: " + XMLHttpRequest.toString() + "\n\nStatus: " + textStatus + "\n\nError: " + errorThrown);
        },
        success: function (result) {
            console.log(result);
            ko.applyBindings(result.Student);
            $(".f_loading div").fadeOut(function () {
                $(".f_load").fadeIn();
            });
        }
    });
}

function api_WorkshopBookingCancel(workshopId, studentId, userId) {
    $.ajax({
        
        type: "Post",
        beforeSend: function (request) {
            request.setRequestHeader("AppKey", "123456");
        },
        contentType: "application/json",
        url: JsonUrl + "api/workshop/booking/cancel?workshopId=" + workshopId + "&studentId=" + studentId + "&userId=" + userId,
        dataType: "json",
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            alert("Request: " + XMLHttpRequest.toString() + "\n\nStatus: " + textStatus + "\n\nError: " + errorThrown);
        },
        success: function (result) {
            if (result.IsSuccess == true) {
                alert("Cancel Success");
            } else {
                alert("Error:"+result.DisplayMessage);
            }
        }
    })
}