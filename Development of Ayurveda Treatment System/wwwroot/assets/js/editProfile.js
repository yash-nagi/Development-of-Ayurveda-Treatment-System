(function () {
  function showStep($root, idx) {
    const $steps = $root.find(".form-step");
    const total = $steps.length;

    $steps.removeClass("active").eq(idx).addClass("active");

    $root.find("#prevBtn").toggle(idx > 0);
    $root.find("#nextBtn").toggle(idx < total - 1);
    $root.find("#submitBtn").toggleClass("d-none", idx !== total - 1);

    const pct = ((idx + 1) / total) * 100;
    $root.find("#progressBar").css("width", pct + "%");
    $root.find("#progressText").text(`Step ${idx + 1} of ${total}`);
  }

  window.setupEditProfileStepper = function (rootSelector) {
    const $root = $(rootSelector || "#contentArea").find(".register-section").first();
    if (!$root.length) {
      console.warn("setupEditProfileStepper: .register-section not found");
      return;
    }
    $root.attr("data-step", 0);   // <-- use attr
    showStep($root, 0);
  };

  $(document).on("click", "#nextBtn", function (e) {
    e.preventDefault();
    const $root = $(this).closest(".register-section");
    const total = $root.find(".form-step").length;
    let step = parseInt($root.attr("data-step")) || 0;  // <-- use attr
    if (step < total - 1) step++;
    $root.attr("data-step", step);
    showStep($root, step);
  });

  $(document).on("click", "#prevBtn", function (e) {
    e.preventDefault();
    const $root = $(this).closest(".register-section");
    let step = parseInt($root.attr("data-step")) || 0;
    if (step > 0) step--;
    $root.attr("data-step", step);
    showStep($root, step);
  });
})();
