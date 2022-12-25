var canvas;

function drawPolygon(x_1, y_1, x_2, y_2, x_3, y_3) {
    if (canvas == undefined)
        var canvas = document.getElementById('canvasbox');

    if (canvas.getContext) {
        var objctx = canvas.getContext('2d');
        objctx.beginPath();
        objctx.moveTo(x_1, y_1);
        objctx.lineTo(x_2, y_2);
        objctx.lineTo(x_3, y_3);
        objctx.closePath();
        objctx.stroke();

    } else {
        alert('You need HTML5 compatible browser to see this demo.');
    }
}

function clearCanvas() {
    if (canvas == undefined)
        var canvas = document.getElementById('canvasbox');

    if (canvas.getContext) {
        var objctx = canvas.getContext('2d');
        objctx.clearRect(0, 0, canvas.width, canvas.height);
    }
}