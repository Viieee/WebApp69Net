$(document).ready(() => {
    $("#dataTablesCountryUser").DataTable({
        "ajax": {
            url: "/Country/GetAll",
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
                    return `${row.region.name}`;
                }
            }
        ]
    })
    $("#dataTablesCountry").DataTable({
        "ajax": {
            url: "/Country/GetAll",
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
                    return `${row.region.name}`;
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
                        <button class="btn btn-secondary" onclick="addModalCountry(${row.id})" data-toggle="modal" data-target="#modalCountry">
                            <a class="iconify" data-tooltip=tooltip data-icon="octicon-pencil" data-toggle="tooltip" data-placement="top" title="Edit"></a>
                        </button>
                        <button class="btn btn-secondary" onclick="deleteModalCountry(${row.id})">
                            <a class="iconify" data-tooltip=tooltip data-icon="octicon-x" data-toggle="tooltip" data-placement="top" title="Delete"></a>
                        </button>
                    `;
                }
            }
        ]
    })
})

function deleteModalCountry(id) {
    $.ajax({
        type: 'DELETE',
        url: `/Country/Delete/${id}`
    }).done(result => {
        /*        console.log(result);*/
        /*        $("#modalCountry .close").click()*/
        let table = $("#dataTablesCountry").DataTable();
        table.ajax.reload();
    }).fail(e => { console.log(e) })
}

async function addModalCountry(id = null) {
    let data;
    let optionalPropertyInput = "";
    let operation = "add";
    let ButtonName = "Add";
    if (id != null) {
        await $.ajax({
            type: 'GET',
            url: `/Country/Get/${id}`,
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
        <h4>Country</h4>
        <hr />
        <div class="row">
            <div class="col-md-4">
                <form>
                    <div class="form-group">
                        <label class="control-label">Name</label>
                        <input class="form-control" id="nameInput" ${optionalPropertyInput}/>
                    </div>
                    <div class="form-group">
                        <label class="control-label">Region</label>
                        <select class="form-control" id="regionSelection">
                        </select>
                    </div>
                    <div class="form-group">
                        <button class="btn btn-primary" id="${operation}-operation-Country">${ButtonName}</button>
                    </div>
                </form>
            </div>
        </div>
    `
    $("#modalContentCountry").html(html);

    $.ajax({
        type: 'GET',
        url: '/Region/GetAll',
        dataSrc: "",
        dataType: "JSON"
    }).done(result => {
        console.log(data);
        let options = "";
        let optionalPropertySelect = "";
        result.forEach(_data => {
            if (id != null && data.region_Id.toString() === _data.id.toString()) {
                optionalPropertySelect = "selected"
            } else {
                optionalPropertySelect = ""
            }
            options += `<option value="${_data.id}" ${optionalPropertySelect}>${_data.name}</option>`
        })
        $("#regionSelection").html(options);
    }).fail(e => console.log(e));

    if (id == null) {
        // button add
        let buttonAdd = document.getElementById("add-operation-Country");
        buttonAdd.addEventListener("click", function (event) {
            event.preventDefault();
            let Obj = new Object();
            Obj.name = $("#nameInput").val();
            Obj.region_Id = $("#regionSelection").val();
            console.log(Obj);
            $.ajax({
                type: 'POST',
                url: '/Country/Post',
                data: Obj
            }).done(result => {
                console.log(result);
                $("#modalCountry .close").click()
                let table = $("#dataTablesCountry").DataTable();
                table.ajax.reload();
            }).fail(e => { console.log(e) })
        });
    } else {
        // button edit
        let buttonEdit = document.getElementById("edit-operation-Country");
        buttonEdit.addEventListener("click", function (event) {
            event.preventDefault();
            let Obj = new Object();
            Obj.name = $("#nameInput").val();
            Obj.region_Id = $("#regionSelection").val();
            console.log(Obj);
            $.ajax({
                type: 'PUT',
                url: `/Country/Put/${data.id}`,
                data: Obj
            }).done(result => {
                $("#modalCountry .close").click()
                let table = $("#dataTablesCountry").DataTable();
                table.ajax.reload();
            }).fail(e => console.log(e))
        });
    }
}