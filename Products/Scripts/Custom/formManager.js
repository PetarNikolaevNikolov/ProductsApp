var FormManager = new function () {

    var webApiUri = null;
    var webApiFilterMethod = null;
    var formControls = null;
    var textResources = null;
    var CustomBehaviours = null;
    var selectFilter = null;
    var ddlList = null;

    function ajaxHelper(uri, method, data, isFiterUsed) {
        $("#circularG").show();
        return $.ajax({
            type: method,
            url: isFiterUsed == true ? uri.substring(0, uri.length - 1) + 'Filter/' : uri,
            dataType: 'json',
            contentType: 'application/json',
            data: isFiterUsed == true ? data : (data ? JSON.stringify(data) : null)
        }).fail(function (jqXHR, textStatus, errorThrown) {
            if (!extractErrors(jqXHR)) {
                showCustomError("Unexpected error occured during request");
            }
        }).always(function () {
            $("#circularG").hide();
        });
    }

    function showCustomError(errorText) {
        var cache = formControls.valSummary.children();
        formControls.valSummary.text(errorText).append(cache);
        formControls.valSummary.show();

        $('.close').click(function () {
            $('.alert').hide();
        })
    }

    function cleanValidationErrors() {
        $('.field-validation-error')
            .removeClass('field-validation-error')
            .addClass('field-validation-valid');

        $('.input-validation-error')
            .removeClass('input-validation-error')
            .addClass('valid');

        formControls.valSummary.hide();
    }

    function extractErrors(jqXhr) {
        var validator = $('form.edit-form').validate();
        var response = null;
        var errors = {};
        var customMessage = null;
        var result = false;
        //ignore the unexpected erros and work only with 400
        if (jqXhr.status == 400) {
            response = JSON.parse(jqXhr.responseText);
        }
        if (response != null) {
            var modelState = response.ModelState;
            for (var key in modelState) {
                if (modelState.hasOwnProperty(key)) {
                    if (Array.isArray(modelState[key])) {
                        var keyToInsert = key;
                        if (key.indexOf('.') > 0) {
                            var splittedKey = key.split('.');
                            keyToInsert = splittedKey[splittedKey.length - 1];
                        }
                        if (key == 'customMessage') {
                            customMessage = modelState[key];
                        }
                        else {
                            errors[keyToInsert] = modelState[key][0];
                            result = true;
                        }
                    }
                }
            }
        }

        if (result) {
            validator.showErrors(errors);
        }

        if (customMessage != null) {
            showCustomError(customMessage);
            result = true;
        }

        return result;
    }

    function buildTable(data) {
        var rows = "";
        $.each(data, function (index, item) {
            rows += CustomBehaviours.buildRow(item);
        });
        formControls.tableBody.html(rows);
    }

    function reloadData() {
        formControls.tableBody.children().remove();
        var isFilterUsed = false;
        if (selectFilter != null && typeof(selectFilter) != 'undefined') {
            isFilterUsed = true;
        }
        ajaxHelper(webApiUri, 'GET', selectFilter, isFilterUsed).done(function (data) {
            buildTable(data);
            attachTableEvents();
        });
    }

    function deleteEntity(id) {
        ajaxHelper(webApiUri + id, 'DELETE', id).done(function (item) {
            reloadData();
        });
    }

    function clearEditorControls(editorContainer) {
        cleanValidationErrors();
        editorContainer.find('input[type=text], textarea, input[type=hidden]').val('');
        editorContainer.find('img').attr('src', '');
        editorContainer.find('img').attr('data-extension', '');
        editorContainer.find("input[type=file]").val('');
        $("#upload-file-info").text('');
    }

    function displayEditForm(id) {
        if (id != null && id > 0) {
            ajaxHelper(webApiUri + id, 'GET', id).done(function (item) {
                formControls.pnlEditHead.text(textResources.pnlEditHeadUpdateText);
                cleanValidationErrors();
                CustomBehaviours.populateEditorControls(item);
                formControls.editContainer.show();
            });
        } else {
            formControls.pnlEditHead.text(textResources.pnlEditHeadInsText);
            clearEditorControls(formControls.editContainer);
            formControls.editContainer.show();
        }
    }

    function attachTableEvents() {
        $(".edit-btn").click(function () {
            displayEditForm($(this).attr('data-id'));
        });

        $(".delete-btn").click(function () {
            var result = confirm("Delete the selected record?");
            if (result == true) {
                formControls.editContainer.hide();
                deleteEntity($(this).attr('data-id'));
            }
        });
    }

    function attachFormEvents() {

        formControls.btnAddNew.click(function () {
            displayEditForm(null);
        });

        formControls.btnEditCancel.click(function () {
            formControls.editContainer.hide();
        });

        formControls.btnEditSubmit.click(function () {
            var formData = CustomBehaviours.getFormData();
            if (formData.Id == 0) {//insert
                ajaxHelper(webApiUri, 'POST', formData).done(function (formData) {
                    reloadData();
                    formControls.editContainer.hide();
                });
            } else {//update
                ajaxHelper(webApiUri, 'PUT', formData).done(function (formData) {
                    reloadData();
                    formControls.editContainer.hide();
                });
            }
        })

        $(".delete-btn").click(function () {
            var result = confirm("Delete the selected record?");
            if (result == true) {
                deleteEntity($(this).attr('data-id'));
            }
        });
    }

    function initDdl(ddlData) {
        var ddl = $('#' + ddlData.id);
        ddl.find('option').remove();
        ajaxHelper(ddlData.webApiUri, 'GET', false).done(function (data) {
            $.each(data, function (index, dataItem) {
                ddl.append('<option value=' + dataItem.Id + '>' + dataItem.Name + '</option>');
            });
        });
    }

    function initDdls() {
        if (ddlList != null && typeof (ddlList) != 'undefined') {
            $.each(ddlList, function (index, ddlData) {
                initDdl(ddlData);
            });
        }
    }

    this.getSelectFilter = function () {
        return selectFilter;
    }

    this.setSelectFilter = function (val) {
        selectFilter = val;
    }


    this.reloadTableData = function () {
        reloadData();
    }

    this.initTable = function (initObj) {
        webApiUri = initObj.webApiUri;
        formControls = initObj.formControls;
        textResources = initObj.textResources;
        CustomBehaviours = initObj.CustomBehaviours;
        selectFilter = initObj.selectFilter;
        ddlList = initObj.ddlList;

        initDdls();
        reloadData();
        attachFormEvents();
    }
}