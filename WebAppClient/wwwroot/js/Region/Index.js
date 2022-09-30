$(document).ready(() => {
    $("#dataTablesRegion").DataTable({
        "ajax": {
            url: "/Region/GetAll",
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
                    $('body').tooltip({
                        selector: "[data-tooltip=tooltip]",
                        container: "body"
                    }); // activating the tooltip
                    return `
                        <button class="btn btn-secondary" onclick="addModalRegion(${row.id})" data-toggle="modal" data-target="#modalRegion">
                            <a class="iconify" data-tooltip=tooltip data-icon="octicon-pencil" data-toggle="tooltip" data-placement="top" title="Edit"></a>
                        </button>
                        <button class="btn btn-secondary" onclick="deleteModalRegion(${row.id})">
                            <a class="iconify" data-tooltip=tooltip data-icon="octicon-x" data-toggle="tooltip" data-placement="top" title="Delete"></a>
                        </button>
                    `;
                }
            }
        ]
    })
})

function deleteModalRegion(id) {
    $.ajax({
        type: 'DELETE',
        url: `/Region/Delete/${id}`
    }).done(result => {
        /*        console.log(result);*/
        /*        $("#modalRegion .close").click()*/
        let table = $("#dataTablesRegion").DataTable();
        table.ajax.reload();
    }).fail(e => { console.log(e) })
}

async function addModalRegion(id = null) {
    let data;
    let optionalPropertyInput = "";
    let operation = "add";
    let ButtonName = "Add";
    if (id != null) {
        await $.ajax({
            type: 'GET',
            url: `/Region/Get/${id}`,
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
        <h4>Region</h4>
        <hr />
        <div class="row">
            <div class="col-md-4">
                <form>
                    <div class="form-group">
                        <label class="control-label">Name</label>
                        <input class="form-control" id="nameInput" ${optionalPropertyInput}/>
                    </div>
                    <div class="form-group">
                        <button class="btn btn-primary" id="${operation}-operation-Region">${ButtonName}</button>
                    </div>
                </form>
            </div>
        </div>
    `
    $("#modalContentRegion").html(html);

    if (id == null) {
        // button add
        let buttonAdd = document.getElementById("add-operation-Region");
        buttonAdd.addEventListener("click", function (event) {
            event.preventDefault();
            let Obj = new Object();
            Obj.name = $("#nameInput").val();
            console.log(Obj);
            $.ajax({
                type: 'POST',
                url: '/Region/Post',
                data: Obj
            }).done(result => {
                console.log(result);
                $("#modalRegion .close").click()
                let table = $("#dataTablesRegion").DataTable();
                table.ajax.reload();
            }).fail(e => { console.log(e) })
        });
    } else {
        // button edit
        let buttonEdit = document.getElementById("edit-operation-Region");
        buttonEdit.addEventListener("click", function (event) {
            event.preventDefault();
            let Obj = new Object();
            Obj.name = $("#nameInput").val();
            console.log(Obj);
            $.ajax({
                type: 'PUT',
                url: `/Region/Put/${data.id}`,
                data: Obj
            }).done(result => {
                $("#modalRegion .close").click()
                let table = $("#dataTablesRegion").DataTable();
                table.ajax.reload();
            }).fail(e => console.log(e))
        });
    }
}