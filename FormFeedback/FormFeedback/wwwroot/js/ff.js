﻿// Logout
function uLogout() {
    debugger;
    $.ajax({
        "url": "/Home/Logout"
    }).then((result) => {
        window.location.href = '/'
    })
}

// Questions

$(function () {
    debugger;
    var q = $("#questions").DataTable({
        "columnDefs": [
            {
                "searchable": false,
                "orderable": false,
                "targets": 0
            },
            {
                "orderable": false,
                "targets": 4
            }
        ],
        "order": [[1, 'asc']]
    })
    q.on('order.dt search.dt', function () {
        q.column(0, { search: 'applied', order: 'applied' }).nodes().each(function (cell, i) {
            cell.innerHTML = i + 1 + ".";
        });
    }).draw();
});

function qClearScreen() {
    document.getElementById("qIdText").disabled = true;
    $("#qIdText").val('');
    $("#qValueText").val('');
    $("#qTypeText").val('null');
    $("#qTypeText").trigger('change');
    $("#qOptText").val('null');
    $("#qOptText").trigger('change');
    $("#qUpdate").hide();
    $("#qSave").show();
}

function qValidation() {
    if ($("#qValueText").val().trim() == "") {
        Swal.fire({
            icon: 'error',
            title: 'Oops...',
            text: 'Please Fill Question'
        })
    }
    else if ($("#qTypeText").val() == "null") {
        Swal.fire({
            icon: 'error',
            title: 'Oops...',
            text: 'Please Fill Question Type'
        })
    }
    else if ($("#qOptText").val() == "null") {
        Swal.fire({
            icon: 'error',
            title: 'Oops...',
            text: 'Please Fill Option'
        })
    }
    else if ($("#qIdText").val() == "" || $("#qIdText").val() == " ") {
        qSave();
    }
    else {
        debugger
        qEdit($("#qIdText").val());
    }
}

function qSave() {
    debugger;
    var question = new Object();
    question.Q_Name = $("#qValueText").val();
    question.Type = $("#qTypeText").val();
    question.optionId = $("#qOptText").val();
    $.ajax({
        "url": "/Questions/Create",
        "type": "POST",
        "dataType": "json",
        "data": question
    }).then((result) => {
        if (result.statusCode == 200) {
            Swal.fire({
                icon: 'success',
                title: 'Your data has been saved',
                text: 'Success!'
            }).then((hasil) => {
                location.reload();
            });
            $("#qst-modal").modal("hide");
        }
        else {
            Swal.fire({
                icon: 'error',
                title: 'Your data not saved',
                text: 'Failed!'
            })
        }
    })
}

function qGetById(id) {
    debugger
    $.ajax({
        "url": "/Questions/Get/" + id,
        "type": "GET",
        "dataType": "json",
        "data": { Id: id }
    }).then((result) => {
        debugger
        if (result.data != null) {
            debugger
            document.getElementById("qIdText").disabled = true;
            debugger
            $("#qIdText").val(result.data.id);
            debugger
            $("#qValueText").val(result.data.q_Name);
            $("#qTypeText").val(result.data.type);
            $("#qTypeText").trigger('change');
            $("#qOptText").val(result.data.optionId);
            $("#qOptText").trigger('change');
            debugger
            $("#qst-modal").modal("show");
            $("#qUpdate").show();
            $("#qSave").hide();
        }
    })
}

function qEdit(id) {
    var question = new Object();
    debugger
    question.Id = $("#qIdText").val();
    debugger
    question.Q_Name = $("#qValueText").val();
    question.Type = $("#qTypeText").val();
    question.optionId = $("#qOptText").val();
    $.ajax({
        "url": "/Questions/Edit/",
        "type": "POST",
        "dataType": "json",
        "data": { Id: question.Id, Q_Name: question.Q_Name, Type: question.Type, optionId: question.optionId }
    }).then((result) => {
        if (result.statusCode == 200) {
            $("#qst-modal").modal("hide");
            Swal.fire({
                icon: 'success',
                title: 'Your data has been updated',
                text: 'Success!'
            }).then((result) => {
                location.reload();
            });
        }
        else {
            Swal.fire({
                icon: 'error',
                title: 'Your data not updated',
                text: 'Failed!'
            })
        }
    })
}

function qDelete(id) {
    Swal.fire({
        title: 'Are you sure?',
        text: "You won't be able to revert this!",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Yes, delete it!'
    }).then((result) => {
        if (result.value) {
            debugger
            $.ajax({
                "url": "/Questions/Delete/",
                "dataType": "json",
                "data": { Id: id }
            }).then((hasil) => {
                debugger
                if (hasil.data[0] != 0) {
                    Swal.fire({
                        icon: 'success',
                        title: 'Your data has been deleted',
                        text: 'Deleted!'
                    }).then((result) => {
                        location.reload();
                    });
                }
                else {
                    Swal.fire({
                        icon: 'error',
                        title: 'Your data not deleted',
                        text: 'Failed!'
                    })
                }
            })
        }
    })
}

// Options

$(function () {
    debugger;
    var o = $("#options").DataTable({
        "columnDefs": [
            {
                "searchable": false,
                "orderable": false,
                "targets": 0
            },
            {
                "orderable": false,
                "targets": 2
            }
        ],
        "order": [[1, 'asc']]
    });
    o.on('order.dt search.dt', function () {
        o.column(0, { search: 'applied', order: 'applied' }).nodes().each(function (cell, i) {
            cell.innerHTML = i + 1 + ".";
        });
    }).draw();
});

function oClearScreen() {
    document.getElementById("oIdText").disabled = true;
    $("#oIdText").val('');
    $("#oValueText").val('');
    $("#oUpdate").hide();
    $("#oSave").show();
}

function oValidation() {
    if ($("#oValueText").val().trim() == "") {
        Swal.fire({
            icon: 'error',
            title: 'Oops...',
            text: 'Please Fill Option'
        })
    }
    else if ($("#oIdText").val() == "" || $("#oIdText").val() == " ") {
        oSave();
    }
    else {
        debugger
        oEdit($("#oIdText").val());
    }
}

function oSave() {
    var option = new Object();
    debugger;
    option.O_Name = $("#oValueText").val();
    $.ajax({
        "url": "/Options/Create",
        "type": "POST",
        "dataType": "json",
        "data": option
    }).then((result) => {
        debugger;
        if (result.statusCode == 200) {
            Swal.fire({
                icon: 'success',
                title: 'Your data has been saved',
                text: 'Success!'
            }).then((hasil) => {
                location.reload();
            });
            $("#opt-modal").modal("hide");
        }
        else {
            Swal.fire({
                icon: 'error',
                title: 'Your data not saved',
                text: 'Failed!'
            })
        }
    })
}

function oGetById(id) {
    debugger
    $.ajax({
        "url": "/Options/Get/" + id,
        "type": "GET",
        "dataType": "json",
        "data": { Id : id }
    }).then((result) => {
        debugger
        if (result.data != null) {
            debugger
            document.getElementById("oIdText").disabled = true;
            debugger
            $("#oIdText").val(result.data.id);
            debugger
            $("#oValueText").val(result.data.o_Name);
            debugger
            $("#opt-modal").modal("show");
            $("#oUpdate").show();
            $("#oSave").hide();
        }
    })
}

function oEdit(id) {
    var option = new Object();
    debugger
    option.Id = $("#oIdText").val();
    debugger
    option.O_Name = $("#oValueText").val();
    $.ajax({
        "url": "/Options/Edit/",
        "type": "POST",
        "dataType": "json",
        "data": { Id: option.Id, O_Name: option.O_Name }
    }).then((result) => {
        if (result.statusCode == 200) {
            $("#opt-modal").modal("hide");
            Swal.fire({
                icon: 'success',
                title: 'Your data has been updated',
                text: 'Success!'
            }).then((result) => {
                location.reload();
            });
        }
        else {
            Swal.fire({
                icon: 'error',
                title: 'Your data not updated',
                text: 'Failed!'
            })
        }
    })
}

function oDelete(id) {
    Swal.fire({
        title: 'Are you sure?',
        text: "You won't be able to revert this!",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Yes, delete it!'
    }).then((result) => {
        if (result.value) {
            debugger
            $.ajax({
                "url": "/Options/Delete/",
                "dataType": "json",
                "data": { Id: id }
            }).then((hasil) => {
                debugger
                if (hasil.data[0] != 0) {
                    Swal.fire({
                        icon: 'success',
                        title: 'Your data has been deleted',
                        text: 'Deleted!'
                    }).then((result) => {
                        location.reload();
                    });
                }
                else {
                    Swal.fire({
                        icon: 'error',
                        title: 'Your data not deleted',
                        text: 'Failed!'
                    })
                }
            })
        }
    })
}

// Points

$(function () {
    debugger;
    var p = $("#points").DataTable({
        "columnDefs": [
            {
                "searchable": false,
                "orderable": false,
                "targets": 0
            },
            {
                "orderable": false,
                "targets": 3
            }
        ],
        "order": [[1, 'asc']]
    });
    p.on('order.dt search.dt', function () {
        p.column(0, { search: 'applied', order: 'applied' }).nodes().each(function (cell, i) {
            cell.innerHTML = i + 1 + ".";
        });
    }).draw();
});

function pClearScreen() {
    document.getElementById("pIdText").disabled = true;
    $("#pIdText").val('');
    $("#pValueText").val('');
    $("#pNoteText").val('');
    $("#pUpdate").hide();
    $("#pSave").show();
}

function pValidation() {
    if ($("#pValueText").val().trim() == "") {
        Swal.fire({
            icon: 'error',
            title: 'Oops...',
            text: 'Please Fill Point'
        })
    }
    else if ($("#pNoteText").val() == "null") {
        Swal.fire({
            icon: 'error',
            title: 'Oops...',
            text: 'Please Fill Note'
        })
    }
    else if ($("#pIdText").val() == "" || $("#pIdText").val() == " ") {
        pSave();
    }
    else {
        debugger
        pEdit($("#pIdText").val());
    }
}

function pSave() {
    var point = new Object();
    debugger;
    point.Value = $("#pValueText").val();
    point.Note = $("#pNoteText").val();
    $.ajax({
        "url": "/Points/Create",
        "type": "POST",
        "dataType": "json",
        "data": point
    }).then((result) => {
        debugger;
        if (result.statusCode == 200) {
            Swal.fire({
                icon: 'success',
                title: 'Your data has been saved',
                text: 'Success!'
            }).then((hasil) => {
                location.reload();
            });
            $("#pts-modal").modal("hide");
        }
        else {
            Swal.fire({
                icon: 'error',
                title: 'Your data not saved',
                text: 'Failed!'
            })
        }
    })
}

function pGetById(id) {
    debugger
    $.ajax({
        "url": "/Points/Get/" + id,
        "type": "GET",
        "dataType": "json",
        "data": { Id: id }
    }).then((result) => {
        debugger
        if (result.data != null) {
            debugger
            document.getElementById("pIdText").disabled = true;
            debugger
            $("#pIdText").val(result.data.id);
            debugger
            $("#pValueText").val(result.data.value);
            $("#pNoteText").val(result.data.note);
            $("#pNoteText").trigger('change');
            debugger
            $("#pts-modal").modal("show");
            $("#pUpdate").show();
            $("#pSave").hide();
        }
    })
}

function pEdit(id) {
    var point = new Object();
    debugger
    point.Id = $("#pIdText").val();
    debugger
    point.Value = $("#pValueText").val();
    point.Note = $("#pNoteText").val();
    $.ajax({
        "url": "/Points/Edit/",
        "type": "POST",
        "dataType": "json",
        "data": { Id: point.Id, Value: point.Value, Note: point.Note }
    }).then((result) => {
        if (result.statusCode == 200) {
            $("#pts-modal").modal("hide");
            Swal.fire({
                icon: 'success',
                title: 'Your data has been updated',
                text: 'Success!'
            }).then((result) => {
                location.reload();
            });
        }
        else {
            Swal.fire({
                icon: 'error',
                title: 'Your data not updated',
                text: 'Failed!'
            })
        }
    })
}

function pDelete(id) {
    Swal.fire({
        title: 'Are you sure?',
        text: "You won't be able to revert this!",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Yes, delete it!'
    }).then((result) => {
        if (result.value) {
            debugger
            $.ajax({
                "url": "/Points/Delete/",
                "dataType": "json",
                "data": { Id: id }
            }).then((hasil) => {
                debugger
                if (hasil.data[0] != 0) {
                    Swal.fire({
                        icon: 'success',
                        title: 'Your data has been deleted',
                        text: 'Deleted!'
                    }).then((result) => {
                        location.reload();
                    });
                }
                else {
                    Swal.fire({
                        icon: 'error',
                        title: 'Your data not deleted',
                        text: 'Failed!'
                    })
                }
            })
        }
    })
}