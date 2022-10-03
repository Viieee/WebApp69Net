$(document).ready(() => {
    $("#dataTablesDepartmentUser").DataTable({
        "ajax": {
            url: "/Department/GetAll",
            type: "GET",
            dataSrc: "",
            dataType: "JSON"
        },
        "columns": [
            {
                "data": "",
                "render": function (data, type, row) {
                    return `${row.id.toString()}`;
                }
            },
            {
                "data": "",
                "render": function (data, type, row) {
                    return `${row.name}`;
                }
            },
            {
                "data": "",
                "render": function (data, type, row) {
                    return `${row.location.streetAddress}`;
                }
            }
        ]
    })
    $("#dataTablesDepartment").DataTable({
        "ajax": {
            url: "/Department/GetAll",
            type: "GET",
            dataSrc: "",
            dataType: "JSON"
        },
        "columns": [
            {
                "data": "",
                "render": function (data, type, row) {
                    return `${row.id.toString()}`;
                }
            },
            {
                "data": "",
                "render": function (data, type, row) {
                    return `${row.name}`;
                }
            },
            {
                "data": "",
                "render": function (data, type, row) {
                    return `${row.location.streetAddress}`;
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
                        <button class="btn btn-secondary" onclick="addModalDepartment(${row.id})" data-toggle="modal" data-target="#modalDepartment">
                            <a class="iconify" data-tooltip=tooltip data-icon="octicon-pencil" data-toggle="tooltip" data-placement="top" title="Edit"></a>
                        </button>
                        <button class="btn btn-secondary" onclick="deleteModalDepartment(${row.id})">
                            <a class="iconify" data-tooltip=tooltip data-icon="octicon-x" data-toggle="tooltip" data-placement="top" title="Delete"></a>
                        </button>
                    `;
                }
            }
        ]
    })
})

function deleteModalDepartment(id) {
    $.ajax({
        type: 'DELETE',
        url: `/Department/Delete/${id}`
    }).done(result => {
        /*        console.log(result);*/
        /*        $("#modalDepartment .close").click()*/
        let table = $("#dataTablesDepartment").DataTable();
        table.ajax.reload();
    }).fail(e => { console.log(e) })
}

async function addModalDepartment(id = null) {
    let data;
    let optionalPropertyInput = "";
    let operation = "add";
    let ButtonName = "Add";
    if (id != null) {
        await $.ajax({
            type: 'GET',
            url: `/Department/Get/${id}`,
            dataSrc: "",
            dataType: "JSON"
        }).done(result => {
            console.log(result);
            data = result;
            operation = "edit";
            ButtonName = "Edit";
            optionalPropertyInput = `value="${result.name}"`;
        }).fail(e => console.log(e));
    }
    let html = `
        <h4>Department</h4>
        <hr />
        <div class="row">
            <div class="col-md-4">
                <form>
                    <div class="form-group">
                        <label class="control-label">Name</label>
                        <input class="form-control" id="nameInput" ${optionalPropertyInput}/>
                    </div>
                    <div class="form-group">
                        <label class="control-label">Location</label>
                        <select class="form-control" id="locationSelection">
                        </select>
                    </div>
                    <div class="form-group">
                        <button class="btn btn-primary" id="${operation}-operation-Department">${ButtonName}</button>
                    </div>
                </form>
            </div>
        </div>
    `
    $("#modalContentDepartment").html(html);

    $.ajax({
        type: 'GET',
        url: '/Location/GetAll',
        dataSrc: "",
        dataType: "JSON"
    }).done(result => {
        console.log(data);
        let options = "";
        let optionalPropertySelect = "";
        result.forEach(_data => {
            if (id != null && data.location_Id.toString() === _data.id.toString()) {
                optionalPropertySelect = "selected"
            } else {
                optionalPropertySelect = ""
            }
            options += `<option value="${_data.id}" ${optionalPropertySelect}>${_data.streetAddress}</option>`
        })
        $("#locationSelection").html(options);
    }).fail(e => console.log(e));

    if (id == null) {
        // button add
        let buttonAdd = document.getElementById("add-operation-Department");
        buttonAdd.addEventListener("click", function (event) {
            event.preventDefault();
            let Obj = new Object();
            Obj.name = $("#nameInput").val();
            Obj.location_Id = $("#locationSelection").val();
            console.log(Obj);
            $.ajax({
                type: 'POST',
                url: '/Department/Post',
                data: Obj
            }).done(result => {
                console.log(result);
                $("#modalDepartment .close").click()
                let table = $("#dataTablesDepartment").DataTable();
                table.ajax.reload();
            }).fail(e => { console.log(e) })
        });
    } else {
        // button edit
        let buttonEdit = document.getElementById("edit-operation-Department");
        buttonEdit.addEventListener("click", function (event) {
            event.preventDefault();
            let Obj = new Object();
            Obj.name = $("#nameInput").val();
            Obj.location_Id = $("#locationSelection").val();
            console.log(Obj);
            $.ajax({
                type: 'PUT',
                url: `/Department/Put/${data.id}`,
                data: Obj
            }).done(result => {
                $("#modalDepartment .close").click()
                let table = $("#dataTablesDepartment").DataTable();
                table.ajax.reload();
            }).fail(e => console.log(e))
        });
    }
}