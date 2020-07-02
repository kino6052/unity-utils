const loadTexture = () => {
  var img = document.getElementById("image");
  var canvas = document.createElement("canvas");
  document.children[0].appendChild(canvas);
  canvas.setAttribute("width", "128px");
  canvas.setAttribute("height", "128px");
  var ctx = canvas.getContext("2d");
  ctx.drawImage(
    img, 
    0, 0, img.width, img.height,      // source rectangle
    0, 0, 128, 128 // destination rectangle
  );
  var dataURL = canvas.toDataURL("image/jpeg");
  dataURL = dataURL.replace("data:image/jpeg;base64,", "");
  // const buf = Buffer.from(dataURL, 'base64'); // Ta-da
  console.warn(dataURL); 
}
window.addEventListener("load", () => {
  console.warn('load');
  loadTexture();
})
