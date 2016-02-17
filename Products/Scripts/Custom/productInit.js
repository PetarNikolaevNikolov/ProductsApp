var ProductInit = new function () {
    this.webApiUri = '/api/product/';

    this.ddlList = [{ id: 'CategoryId', webApiUri: '/api/category/' }]

    this.formControls = {
        tableBody: $("#productTableBody"),
        editContainer: $('#productEditContainer'),
        btnEditCancel: $('#btnCategoryEditCancel'),
        btnEditSubmit: $('#btnCategoryEditSubmit'),
        btnAddNew: $('#btnAddNewProduct'),
        pnlEditHead: $('#pnlProductEditHead'),
        valSummary: $('#valSummaryProducts')
    }

    this.getFilterData = function () {
        var productFilter = {
            Id: $('#searchId').val(),
            Name: $('#searchName').val(),
            CategoryName: $('#searchCategoryName').val()
        }
        return productFilter;
    }

    this.CustomBehaviours = new function () {
        this.buildRow = function (dataItem) {
            var row = '<tr><td>{0}</td><td>{1}</td><td>{2}</td><td>{3}</td><td><img src="{4}" class="img-thumbnail" width="100"/></td>'
                + '<td><div class="pull-right">'
                    + '<button type="button" class="btn btn-primary edit-btn" data-id="{5}" style="margin-right: 4px;"><span class="glyphicon glyphicon-edit"></span>Edit</button>'
                    + '<button type="button" class="btn btn-danger delete-btn" data-id="{6}"><span class="glyphicon glyphicon-remove"></span>Detele</button>'
                + '</div></td></tr>';
            return row.format(dataItem.Id, dataItem.Name, dataItem.CategoryName, dataItem.Description, dataItem.ImageUrl, dataItem.Id, dataItem.Id);
        }

        this.populateEditorControls = function (item) {
            $("#Id").val(item.Id);
            $("#Name").val(item.Name);
            $("#Description").val(item.Description);
            $("#CategoryId").val(item.CategoryId);
            var img = $("#img");
            img.attr('src', item.ImageUrl);
            img.attr('data-extension', '');
            $("#upload-file-info").text('');
            $("#fileInput").val('');
        }

        this.getFormData = function () {
            var idVal = $("#Id").val();
            var img = $("#img");
            var imgExtension = img.attr('data-extension');
            var product = {
                Id: idVal ? idVal : 0,
                Name: $("#Name").val(),
                Description: $("#Description").val(),
                CategoryId: $("#CategoryId").val(),
                ImageUrl: imgExtension == null || imgExtension == '' ? $("#img").attr('src') : null,
                ImageData: imgExtension == null || imgExtension == '' ? null : $("#img").attr('src'),
                ImageExtension: imgExtension == null || imgExtension == '' ? null : $("#img").attr('data-extension')
            }
            return product;
        }
    }

    this.selectFilter = this.getFilterData();

    this.textResources = {
        pnlEditHeadUpdateText: 'Update Product',
        pnlEditHeadInsText: 'Add New Product'
    }
}