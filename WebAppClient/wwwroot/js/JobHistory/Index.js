$(document).ready(() => {
    $("#dataTablesJobHistoryUser").DataTable({
        "ajax": {
            url: "/JobHistory/GetAll",
            type: "GET",
            dataSrc: "",
            dataType: "JSON"
        },
        "columns": [
            {
                "data": "",
                "render": function (data, type, row) {
                    return `${row.employee.firstName} ${row.employee.lastName}`;
                }
            },
            {
                "data": "",
                "render": function (data, type, row) {
                    var startDate = new Date(row.startDate);
                    return `${startDate.getUTCDate()} - ${startDate.getUTCMonth() + 1} - ${startDate.getUTCFullYear()}`;
                }
            },
            {
                "data": "",
                "render": function (data, type, row) {
                    var endDate = new Date(row.endDate);
                    return `${endDate.getUTCDate()} - ${endDate.getUTCMonth() + 1} - ${endDate.getUTCFullYear()}`;
                }
            },
            {
                "data": "",
                "render": function (data, type, row) {
                    return `${row.job.title}`;
                }
            },
            {
                "data": "",
                "render": function (data, type, row) {
                    return `${row.department.name}`;
                }
            }
        ]
    })
    $("#dataTablesJobHistory").DataTable({
        "ajax": {
            url: "/JobHistory/GetAll",
            type: "GET",
            dataSrc: "",
            dataType: "JSON"
        },
        "columns": [
            {
                "data": "",
                "render": function (data, type, row) {
                    return `${row.employee.firstName} ${row.employee.lastName}`;
                }
            },
            {
                "data": "",
                "render": function (data, type, row) {
                    var startDate = new Date(row.startDate);
                    return `${startDate.getUTCDate()} - ${startDate.getUTCMonth() + 1} - ${startDate.getUTCFullYear()}`;
                }
            },
            {
                "data": "",
                "render": function (data, type, row) {
                    var endDate = new Date(row.endDate);
                    return `${endDate.getUTCDate()} - ${endDate.getUTCMonth() + 1} - ${endDate.getUTCFullYear()}`;
                }
            },
            {
                "data": "",
                "render": function (data, type, row) {
                    return `${row.job.title}`;
                }
            },
            {
                "data": "",
                "render": function (data, type, row) {
                    return `${row.department.name}`;
                }
            },
            {
                "data": "",
                "render": function (data, type, row) {
                    $('body').tooltip({
                        selector: "[data-tooltip=tooltip]",
                        container: "body"
                    }); // activating the tooltip
                    return `
                        <button class="btn btn-secondary" onclick="addModalJobHistory(${row.id})" data-toggle="modal" data-target="#modalJobHistory">
                            <a class="iconify" data-tooltip=tooltip data-icon="octicon-pencil" data-toggle="tooltip" data-placement="top" title="Edit"></a>
                        </button>
                        <button class="btn btn-secondary" onclick="deleteModalJobHistory(${row.id})">
                            <a class="iconify" data-tooltip=tooltip data-icon="octicon-x" data-toggle="tooltip" data-placement="top" title="Delete"></a>
                        </button>
                    `;
                }
            }
        ]
    })
})

function deleteModalJobHistory(id) {
    $.ajax({
        type: 'DELETE',
        url: `/JobHistory/Delete/${id}`
    }).done(result => {
        /*        console.log(result);*/
        /*        $("#modalJobHistory .close").click()*/
        let table = $("#dataTablesJobHistory").DataTable();
        table.ajax.reload();
    }).fail(e => { console.log(e) })
}

async function addModalJobHistory(id = null) {
    let data;
    let optionalPropertyInputStartDate = "";
    let optionalPropertyInputEndDate = "";
    let operation = "add";
    let ButtonName = "Add";
    if (id != null) {
        await $.ajax({
            type: 'GET',
            url: `/JobHistory/Get/${id}`,
            dataSrc: "",
            dataType: "JSON"
        }).done(result => {
            console.log(result);
            data = result;
            operation = "edit";
            ButtonName = "Edit";
            var startDate = new Date(result.startDate);
            var startDateDate = startDate.getUTCDate();
            var startDateMonth = startDate.getUTCMonth() + 1;
            if (startDateMonth < 10) {
                startDateMonth = `0${startDateMonth}`;
            }
            var startDateYear = startDate.getUTCFullYear();
            var endDate = new Date(result.endDate);
            var endDateDate = endDate.getUTCDate();
            var endDateMonth = endDate.getUTCMonth() + 1;
            if (endDateMonth < 10) {
                endDateMonth = `0${endDateMonth}`;
            }
            var endDateYear = endDate.getUTCFullYear();
            optionalPropertyInputStartDate = `value="${startDateYear}-${startDateMonth}-${startDateDate}"`;
            optionalPropertyInputEndDate = `value="${endDateYear}-${endDateMonth}-${endDateDate}"`;
            console.log(optionalPropertyInputEndDate);
        }).fail(e => console.log(e));
    }
    let html = `
        <h4>Job History</h4>
        <hr />
        <div class="row">
            <div class="col-md-4">
                <form>
                    <div class="form-group">
                        <label class="control-label">Employee</label>
                        <select class="form-control" id="employeeSelection">
                        </select>
                    </div>
                    <div class="form-group">
                        <label class="control-label">Start Date</label>
                        <input type="date" class="form-control" id="startDateInput" ${optionalPropertyInputStartDate}/>
                    </div>
                    <div class="form-group">
                        <label class="control-label">End Date</label>
                        <input type="date" class="form-control" id="endDateInput" ${optionalPropertyInputEndDate}/>
                    </div>
                    <div class="form-group">
                        <label class="control-label">Job</label>
                        <select class="form-control" id="jobSelection">
                        </select>
                    </div>
                    <div class="form-group">
                        <label class="control-label">Department</label>
                        <select class="form-control" id="departmentSelection">
                        </select>
                    </div>
                    <div class="form-group">
                        <button class="btn btn-primary" id="${operation}-operation-JobHistory">${ButtonName}</button>
                    </div>
                </form>
            </div>
        </div>
    `
    $("#modalContentJobHistory").html(html);

    $.ajax({
        type: 'GET',
        url: '/Department/GetAll',
        dataSrc: "",
        dataType: "JSON"
    }).done(result => {
        console.log(data);
        console.log(result);
        let options = "";
        let optionalPropertySelect = "";
        result.forEach(_data => {
            if (id != null && data.department_Id.toString() === _data.id.toString()) {
                optionalPropertySelect = "selected"
            } else {
                optionalPropertySelect = ""
            }
            options += `<option value="${_data.id}" ${optionalPropertySelect}>${_data.name}</option>`
        })
        $("#departmentSelection").html(options);
    }).fail(e => console.log(e));

    $.ajax({
        type: 'GET',
        url: '/Job/GetAll',
        dataSrc: "",
        dataType: "JSON"
    }).done(result => {
        console.log(data);
        console.log(result);
        let options = "";
        let optionalPropertySelect = "";
        result.forEach(_data => {
            if (id != null && data.job_Id.toString() === _data.id.toString()) {
                optionalPropertySelect = "selected"
            } else {
                optionalPropertySelect = ""
            }
            options += `<option value="${_data.id}" ${optionalPropertySelect}>${_data.title}</option>`
        })
        $("#jobSelection").html(options);
    }).fail(e => console.log(e));

    $.ajax({
        type: 'GET',
        url: '/Employee/GetAll',
        dataSrc: "",
        dataType: "JSON"
    }).done(result => {
        console.log(data);
        console.log(result);
        let options = "";
        let optionalPropertySelect = "";
        result.forEach(_data => {
            if (id != null && data.id.toString() === _data.id.toString()) {
                optionalPropertySelect = "selected"
            } else {
                optionalPropertySelect = ""
            }
            options += `<option value="${_data.id}" ${optionalPropertySelect}>${_data.firstName} ${_data.lastName}</option>`
        })
        $("#employeeSelection").html(options);
    }).fail(e => console.log(e));

    if (id == null) {
        // button add
        let buttonAdd = document.getElementById("add-operation-JobHistory");
        buttonAdd.addEventListener("click", function (event) {
            event.preventDefault();
            let Obj = new Object();
            Obj.id = $("#employeeSelection").val();
            Obj.startDate = $("#startDateInput").val();
            Obj.endDate = $("#endDateInput").val();
            Obj.job_Id = $("#jobSelection").val();
            Obj.department_Id = $("#departmentSelection").val();
            console.log(Obj);
            $.ajax({
                type: 'POST',
                url: '/JobHistory/Post',
                data: Obj
            }).done(result => {
                console.log(result);
                $("#modalJobHistory .close").click()
                let table = $("#dataTablesJobHistory").DataTable();
                table.ajax.reload();
            }).fail(e => { console.log(e) })
        });
    } else {
        // button edit
        let buttonEdit = document.getElementById("edit-operation-JobHistory");
        buttonEdit.addEventListener("click", function (event) {
            event.preventDefault();
            let Obj = new Object();
            Obj.id = $("#employeeSelection").val();
            Obj.startDate = $("#startDateInput").val();
            Obj.endDate = $("#endDateInput").val();
            Obj.job_Id = $("#jobSelection").val();
            Obj.department_Id = $("#departmentSelection").val();
            console.log(Obj);
            $.ajax({
                type: 'PUT',
                url: `/JobHistory/Put/${data.id}`,
                data: Obj
            }).done(result => {
                $("#modalJobHistory .close").click()
                let table = $("#dataTablesJobHistory").DataTable();
                table.ajax.reload();
            }).fail(e => console.log(e))
        });
    }
}