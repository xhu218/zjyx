(function ($) {
    $(function () {

        var _$form = $('#TaskCreationForm');

        _$form.find('input:first').focus();

        _$form.validate();

        _$form.find('button[type=submit]')
            .click(function (e) {
                e.preventDefault();

                if (!_$form.valid()) {
                    return;
                }
                debugger;
                var input = _$form.serializeFormToObject();
                abp.services.app.myTask.create(input)
                    .done(function () {
                        location.href = '/Tasks';
                    });
            });
    });
})(jQuery);