
new DataTable('#laTablaDeProducto');

$(document).ready(function () {
	$("#miSweetAlert").on("click", function (event) {
		Swal.fire({
			title: "Good job!",
			text: "You clicked the button!",
			icon: "success"
		});
	});

})