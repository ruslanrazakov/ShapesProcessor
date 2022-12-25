var canvas;

function drawTriangle(x_1, y_1, x_2, y_2, x_3, y_3) {
    if (canvas == undefined)
        var canvas = document.getElementById('canvasbox');

    if (canvas.getContext) {
        var objctx = canvas.getContext('2d');
        objctx.beginPath();
        objctx.moveTo(x_1, y_1);
        objctx.lineTo(x_2, y_2);
        objctx.lineTo(x_3, y_3);
        objctx.fillStyle = '#f00';
        objctx.fill();
        objctx.stroke();

    } else {
        alert('You need HTML5 compatible browser to see this demo.');
    }
}

function drawRectangle(x_1, y_1, x_2, y_2, x_3, y_3, x_4, y_4) {
    if (canvas == undefined)
        var canvas = document.getElementById('canvasbox');

    if (canvas.getContext) {
        var objctx = canvas.getContext('2d');
        objctx.beginPath();
        objctx.moveTo(x_1, y_1);
        objctx.lineTo(x_2, y_2);
        objctx.lineTo(x_3, y_3);
        objctx.lineTo(x_4, y_4);
        objctx.fillStyle = '#f00';
        objctx.fill();
        objctx.stroke();

    } else {
        alert('You need HTML5 compatible browser to see this demo.');
    }
}

function drawCircle(x, y, radius) {
    if (canvas == undefined)
        var canvas = document.getElementById('canvasbox');

    if (canvas.getContext) {
        var objctx = canvas.getContext('2d');
        objctx.beginPath();
        objctx.arc(x, y, radius, 0, 2 * Math.PI);
        objctx.fillStyle = '#f00';
        objctx.fill();
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