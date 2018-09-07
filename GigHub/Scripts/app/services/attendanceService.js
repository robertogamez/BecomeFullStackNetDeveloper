var AttendanceService = function () {
    var createAttendance = function (gigId, done, fail) {
        $.post('/api/attendances', { gigId: gigId })
            .then(done, fail);
    };

    var deleteAttendance = function (gigId, done, fail) {
        $.ajax({
            url: '/api/attendances/' + gigId,
            method: 'DELETE'
        }).then(done, fail);
    }

    return {
        createAttendance: createAttendance,
        deleteAttendance: deleteAttendance
    };
}();