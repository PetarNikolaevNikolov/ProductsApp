var CategoryInit = new function () {
    this.webApiUri = '/api/category/';
    this.formControls = {
        tableBody: $("#categoryTableBody"),
        editContainer: $('#categoryEditContainer'),
        btnEditCancel: $('#btnCategoryEditCancel'),
        btnEditSubmit: $('#btnCategoryEditSubmit'),
        btnAddNew: $('#btnAddNewCategory'),
        pnlEditHead: $('#pnlCategotyEditHead'),
        valSummary: $('#valSummaryCategories')
    }

    this.CustomBehaviours = new function () {
        this.buildRow = function (dataItem) {
            var row = '<tr><td>{0}</td><td>{1}</td><td>{2}</td>'
                + '<td><div class="pull-right">'
                    + '<button type="button" class="btn btn-primary edit-btn" data-id="{3}" style="margin-right: 4px;"><span class="glyphicon glyphicon-edit"></span>Edit</button>'
                    + '<button type="button" class="btn btn-danger delete-btn" data-id="{4}"><span class="glyphicon glyphicon-remove"></span>Detele</button>'
                + '</div></td></tr>';
            return row.format(dataItem.Id, dataItem.Name, dataItem.Description, dataItem.Id, dataItem.Id);;
        }

        this.populateEditorControls = function (item) {
            $("#Id").val(item.Id);
            $("#Name").val(item.Name);
            $("#Description").val(item.Description);
        }

        this.getFormData = function () {
            var idVal = $("#Id").val();
            var category = {
                Id: idVal ? idVal : 0,
                Name: $("#Name").val(),
                Description: $("#Description").val()
            }
            return category;
        }
    }

    this.textResources = {
        pnlEditHeadUpdateText: 'Update Category',
        pnlEditHeadInsText: 'Add New Category'
    }
}