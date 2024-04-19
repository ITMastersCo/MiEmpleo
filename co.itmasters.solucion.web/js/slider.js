function slider(carouselElement, itemFirst, items, iconsArrow, wrapperElement, margin = 0) {
  const carousel = document.querySelector(carouselElement), 
  firstImg = carousel.querySelectorAll(itemFirst)[0],
  images = carousel.getElementsByClassName(items), 
  arrowIcons = document.querySelectorAll(iconsArrow), 
  wrapper = document.getElementById(wrapperElement);

  let isDragStart = false, isDragging = false, prevPageX, prevScrollLeft, positionDiff, widthWrapper;
  const showHideIcons = () => {
    let scrollWidth = carousel.scrollWidth - carousel.clientWidth;
    arrowIcons[0].style.display = carousel.scrollLeft == 0 ? "none" : "block";
    
    arrowIcons[1].style.display =  carousel.scrollLeft == scrollWidth ? "none" : "block";
  };
  arrowIcons.forEach((icon) => {
    icon.addEventListener("click", () => {
      let firstImgWidth = firstImg.clientWidth + margin;
      carousel.scrollLeft += icon.id == "left" ? -firstImgWidth : firstImgWidth;
      setTimeout(() => showHideIcons(), 60);
    });
  });

  const autoSlide = () => {
    if (carousel.scrollLeft == (carousel.scrollWidth - carousel.clientWidth))
      return;
    positionDiff = Math.abs(positionDiff);
    let firstImgWidth = firstImg.clientWidth + margin;
    let valDifference = firstImgWidth - positionDiff;

    if (carousel.scrollLeft > prevScrollLeft) {
      return carousel.scrollLeft += positionDiff > firstImgWidth / 8 ? valDifference : - positionDiff;
    }

    carousel.scrollLeft -= positionDiff > firstImgWidth / 8 ? valDifference :  - positionDiff;
  };

  const dragStart = (e) => {
    isDragStart = true;
    prevPageX = e.pageX || e.touches[0].pageX;
    prevScrollLeft = carousel.scrollLeft;
  };
  const dragging = (e) => {
    if (!isDragStart)
      return;
    e.preventDefault();
    console.log()
    isDragging = true;
    carousel.classList.add("dragging");
    positionDiff = (e.pageX || e.touches[0].pageX) - prevPageX;
    carousel.scrollLeft = prevScrollLeft - positionDiff;
    showHideIcons();
  };
  const dragStop = () => {
    isDragStart = false;
    carousel.classList.remove("dragging");

    if (!isDragging)
      return;
    isDragging = false;
    autoSlide();
  };

  carousel.addEventListener("mousedown", dragStart);
  carousel.addEventListener("touchstart", dragStart);

  carousel.addEventListener("mousemove", dragging);
  carousel.addEventListener("touchmove", dragging);

  carousel.addEventListener("mouseup", dragStop);
  carousel.addEventListener("mouseleave", dragStop);
  carousel.addEventListener("touchend", dragStop);
  const widthImg = () => {
  };
  widthImg();
  wrapper.clientWidth = 20;
}
slider(".carousel",".item-slider","item-slider", ".wrapper-slider i", "wrapper-slider", 14);
slider(".servicios",".servicios-item","servicios-item", ".wrapper-servicios i", "wrapper-servicios", 14) 



 