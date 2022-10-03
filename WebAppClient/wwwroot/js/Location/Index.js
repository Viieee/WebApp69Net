$(document).ready(() => {
    $("#dataTablesLocationUser").DataTable({
        "ajax": {
            url: "/Location/GetAll",
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
                    console.log(row);
                    return `${row.streetAddress}`;
                }
            },
            {
                "data": "",
                "render": function (data, type, row) {
                    return `${row.postalCode}`;
                }
            },
            {
                "data": "",
                "render": function (data, type, row) {
                    return `${row.city}`;
                }
            },
            {
                "data": "",
                "render": function (data, type, row) {
                    return `${row.country.name}`;
                }
            }
        ]
    })
    $("#dataTablesLocation").DataTable({
        "ajax": {
            url: "/Location/GetAll",
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
                    console.log(row);
                    return `${row.streetAddress}`;
                }
            },
            {
                "data": "",
                "render": function (data, type, row) {
                    return `${row.postalCode}`;
                }
            },
            {
                "data": "",
                "render": function (data, type, row) {
                    return `${row.city}`;
                }
            },
            {
                "data": "",
                "render": function (data, type, row) {
                    return `${row.country.name}`;
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
                        <button class="btn btn-secondary" onclick="addModalLocation(${row.id})" data-toggle="modal" data-target="#modalLocation">
                            <a class="iconify" data-tooltip=tooltip data-icon="octicon-pencil" data-toggle="tooltip" data-placement="top" title="Edit"></a>
                        </button>
                        <button class="btn btn-secondary" onclick="deleteModalLocation(${row.id})">
                            <a class="iconify" data-tooltip=tooltip data-icon="octicon-x" data-toggle="tooltip" data-placement="top" title="Delete"></a>
                        </button>
                    `;
                }
            }
        ]
    })
})

function deleteModalLocation(id) {
    $.ajax({
        type: 'DELETE',
        url: `/Location/Delete/${id}`
    }).done(result => {
        /*        console.log(result);*/
        /*        $("#modalLocation .close").click()*/
        let table = $("#dataTablesLocation").DataTable();
        table.ajax.reload();
    }).fail(e => { console.log(e) })
}

async function addModalLocation(id = null) {
    let data;
    let optionalPropertyInputStreetAddress = "";
    let optionalPropertyInputPostalCode = "";
    let optionalPropertyInputCity = "";
    let operation = "add";
    let ButtonName = "Add";
    if (id != null) {
        await $.ajax({
            type: 'GET',
            url: `/Location/Get/${id}`,
            dataSrc: "",
            dataType: "JSON"
        }).done(result => {
            console.log(result);
            data = result;
            operation = "edit";
            ButtonName = "Edit";
            optionalPropertyInputStreetAddress = `value="${result.streetAddress}"`;
            optionalPropertyInputPostalCode = `value="${result.postalCode}"`;
            optionalPropertyInputCity = `value="${result.city}"`;
        }).fail(e => console.log(e));
    }
    let html = `
        <h4>Location</h4>
        <hr />
        <div class="row">
            <div class="col-md-4">
                <form>
                    <div class="form-group">
                        <label class="control-label">Street Address</label>
                        <input class="form-control" id="streetAddressInput" ${optionalPropertyInputStreetAddress}/>
                    </div>
                     <div class="form-group">
                        <label class="control-label">Postal Code</label>
                        <input class="form-control" id="postalCodeInput" ${optionalPropertyInputPostalCode}/>
                    </div>
                     <div class="form-group">
                        <label class="control-label">City</label>
                        <input class="form-control" id="cityInput" ${optionalPropertyInputCity}/>
                    </div>
                    <div class="form-group">
                        <label class="control-label">Country</label>
                        <select class="form-control" id="countrySelection">
                        </select>
                    </div>
                    <div class="form-group">
                        <button class="btn btn-primary" id="${operation}-operation-Location">${ButtonName}</button>
                    </div>
                </form>
            </div>
        </div>
    `
    $("#modalContentLocation").html(html);

    $.ajax({
        type: 'GET',
        url: '/Country/GetAll',
        dataSrc: "",
        dataType: "JSON"
    }).done(result => {
        console.log(data);
        let options = "";
        let optionalPropertySelect = "";
        result.forEach(_data => {
            if (id != null && data.country_Id.toString() === _data.id.toString()) {
                optionalPropertySelect = "selected"
            } else {
                optionalPropertySelect = ""
            }
            options += `<option value="${_data.id}" ${optionalPropertySelect}>${_data.name}</option>`
        })
        $("#countrySelection").html(options);
    }).fail(e => console.log(e));

    if (id == null) {
        // button add
        let buttonAdd = document.getElementById("add-operation-Location");
        buttonAdd.addEventListener("click", function (event) {
            event.preventDefault();
            let Obj = new Object();
            Obj.streetAddress = $("#streetAddressInput").val();
            Obj.postalCode = $("#postalCodeInput").val();
            Obj.city = $("#cityInput").val();
            Obj.country_Id = $("#countrySelection").val();
            console.log(Obj);
            $.ajax({
                type: 'POST',
                url: '/Location/Post',
                data: Obj
            }).done(result => {
                console.log(result);
                $("#modalLocation .close").click()
                let table = $("#dataTablesLocation").DataTable();
                table.ajax.reload();
            }).fail(e => { console.log(e) })
        });
    } else {
        // button edit
        let buttonEdit = document.getElementById("edit-operation-Location");
        buttonEdit.addEventListener("click", function (event) {
            event.preventDefault();
            let Obj = new Object();
            Obj.streetAddress = $("#streetAddressInput").val();
            Obj.postalCode = $("#postalCodeInput").val();
            Obj.city = $("#cityInput").val();
            Obj.country_Id = $("#countrySelection").val();
            console.log(Obj);
            $.ajax({
                type: 'PUT',
                url: `/Location/Put/${data.id}`,
                data: Obj
            }).done(result => {
                $("#modalLocation .close").click()
                let table = $("#dataTablesLocation").DataTable();
                table.ajax.reload();
            }).fail(e => console.log(e))
        });
    }
}