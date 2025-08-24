function loadSection(section) {
    $.ajax({
        url: window.baseUrl,
        type: 'GET',
        data: { section: section }, // sends ?section=Medicine
        success: function (html) {
          $('#contentArea').html(html);   // NOTE: contentArea, not "content"
        },
        error: function () {
            onsole.error("AJAX Error:", status, error);
            console.error("Response:", xhr.responseText);
            $('#contentArea').html('<p>Error ' + xhr.status + ': ' + xhr.responseText + '</p>');
        }
    });
}