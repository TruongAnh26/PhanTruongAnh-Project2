const $ = document.querySelector.bind(document)
const $$ = document.querySelectorAll.bind(document)


console.log($('.owl-next'))

var nextBtn = $('.owl-next')
var productInfo = $('.product-infor')
nextBtn.onclick = () => {
    productInfo.style.amination = 'showInfo 1.5s ease'
    setTimeout(() => {
        productInfo.style.amination='';
    }, 100);
    
}