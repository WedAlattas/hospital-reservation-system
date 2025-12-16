
    $(function () {

        $("#saveBtn").prop("disabled", true);

        // this function is used for reset the slots 
      function resetSlots() {
        $(".slotCb").prop("checked", false).prop("disabled", false);
      }

        // this function is used for reset the slots while changing the doctor and check its slots
      $("#doctorDd").on("change", function () {
        resetSlots();

        const slotsData = $(this).find("option:selected").attr("data-slots");

        if (!slotsData || slotsData.trim() === "") return;


        // get the slots that already belong to the doctor and check them
        const slotIds = slotsData.split(",")
          .map(x => parseInt(x, 10))
          .filter(x => !isNaN(x));

        if (slotIds.length === 0) return;

        $(".slotCb").each(function () {
          const id = parseInt($(this).val(), 10);

          if (slotIds.includes(id)) {
            $(this).prop("checked", true);
          }

        
          $(this).prop("disabled", true);
        });

    

      });

        // this function is used for enable or disable the submit button
        $(document).on("change", ".slotCb", function () {
            const anyChecked = $(".slotCb:checked").length > 0;
            $("#saveBtn").prop("disabled", !anyChecked);
        });


        // hide the error message if the user make any change
        $(document).on("change input", "#doctorDd, .slotCb", function () {
            $("#formError").hide();
        });

    });
