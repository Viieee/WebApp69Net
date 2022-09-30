$(document).ready(() => {
    $("#dataTablesJob").DataTable({
        "ajax": {
            url: "/Job/GetAll",
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
                    return `${row.title}`;
                }
            },
            {
                "data": "",
                "render": function (data, type, row) {
                    return `${row.minSalary}`;
                }
            },
            {
                "data": "",
                "render": function (data, type, row) {
                    return `${row.maxSalary}`;
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
                        <button class="btn btn-secondary" onclick="addModalJob(${row.id})" data-toggle="modal" data-target="#modalJob">
                            <a class="iconify" data-tooltip=tooltip data-icon="octicon-pencil" data-toggle="tooltip" data-placement="top" title="Edit"></a>
                        </button>
                        <button class="btn btn-secondary" onclick="deleteModalJob(${row.id})">
                            <a class="iconify" data-tooltip=tooltip data-icon="octicon-x" data-toggle="tooltip" data-placement="top" title="Delete"></a>
                        </button>
                    `;
                }
            }
        ]
    })
})

function deleteModalJob(id) {
    $.ajax({
        type: 'DELETE',
        url: `/Job/Delete/${id}`
    }).done(result => {
        /*        console.log(result);*/
        /*        $("#modalJob .close").click()*/
        let table = $("#dataTablesJob").DataTable();
        table.ajax.reload();
    }).fail(e => { console.log(e) })
}

async function addModalJob(id = null) {
    let data;
    let optionalPropertyInputTitle = "";
    let optionalPropertyInputMinSalary = "";
    let optionalPropertyInputMaxSalary = "";
    let operation = "add";
    let ButtonName = "Add";
    if (id != null) {
        await $.ajax({
            type: 'GET',
            url: `/Job/Get/${id}`,
            dataSrc: "",
            dataType: "JSON"
        }).done(result => {
            console.log(result);
            data = result;
            operation = "edit";
            ButtonName = "Edit";
            optionalPropertyInputTitle = `value="${result.title}"`;
            optionalPropertyInputMinSalary = `value="${result.minSalary}"`;
            optionalPropertyInputMaxSalary = `value="${result.maxSalary}"`;
        }).fail(e => console.log(e));
    }
    let html = `
        <h4>Job</h4>
        <hr />
        <div class="row">
            <div class="col-md-4">
                <form>
                    <div class="form-group">
                        <label class="control-label">Name</label>
                        <input class="form-control" id="titleInput" ${optionalPropertyInputTitle}/>
                    </div>
                    <div class="form-group">
                        <label class="control-label">Min Salary</label>
                        <input class="form-control" id="minSalaryInput" ${optionalPropertyInputMinSalary}/>
                    </div>
                    <div class="form-group">
                        <label class="control-label">Max Salary</label>
                        <input class="form-control" id="maxSalaryInput" ${optionalPropertyInputMaxSalary}/>
                    </div>
                    <div class="form-group">
                        <button class="btn btn-primary" id="${operation}-operation-Job">${ButtonName}</button>
                    </div>
                </form>
            </div>
        </div>
    `
    $("#modalContentJob").html(html);

    if (id == null) {
        // button add
        let buttonAdd = document.getElementById("add-operation-Job");
        buttonAdd.addEventListener("click", function (event) {
            event.preventDefault();
            let Obj = new Object();
            Obj.title = $("#titleInput").val();
            Obj.minSalary = $("#minSalaryInput").val();
            Obj.maxSalary = $("#maxSalaryInput").val();
            console.log(Obj);
            $.ajax({
                type: 'POST',
                url: '/Job/Post',
                data: Obj
            }).done(result => {
                console.log(result);
                $("#modalJob .close").click()
                let table = $("#dataTablesJob").DataTable();
                table.ajax.reload();
            }).fail(e => { console.log(e) })
        });
    } else {
        // button edit
        let buttonEdit = document.getElementById("edit-operation-Job");
        buttonEdit.addEventListener("click", function (event) {
            event.preventDefault();
            let Obj = new Object();
            Obj.title = $("#titleInput").val();
            Obj.minSalary = $("#minSalaryInput").val();
            Obj.maxSalary = $("#maxSalaryInput").val();
            console.log(Obj);
            $.ajax({
                type: 'PUT',
                url: `/Job/Put/${data.id}`,
                data: Obj
            }).done(result => {
                $("#modalJob .close").click()
                let table = $("#dataTablesJob").DataTable();
                table.ajax.reload();
            }).fail(e => console.log(e))
        });
    }
}