// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
<script>
    document.querySelector("#AllocationType").addEventListener("change", function () {
        var allocationType = this.value;

    // Hide all fields
    document.querySelector("#goodsFields").style.display = "none";
    document.querySelector("#moneyField").style.display = "none";

    // Show fields based on allocation type
    if (allocationType === "AllocateGoods") {
        document.querySelector("#goodsFields").style.display = "block";
        } else if (allocationType === "AllocateMoney") {
        document.querySelector("#moneyField").style.display = "block";
        }
    });
</script>
