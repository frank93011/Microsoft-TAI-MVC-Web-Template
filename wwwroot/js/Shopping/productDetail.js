// 幫購買按鍵加入點擊的所需的function
function onBuyClick(productId, inventory) {
    // 購買時所要call的action
    let buyUrl = $("#buyUrl").data('request-url');

    // 購買數量
    let num = $("#buyQuantity").val();

    // 將購買數量及產品Id包裝成一個物件
    let arg = {
        productId: productId,
        quantity: num,
    }

    // 若存貨小於購買數量則購買失敗
    if (num > inventory) {
        alert("購買數量超出庫存請重新選擇");
        return;
    }

    // [BONUS]: 透過ajax post將商品Id與現有數量傳遞給server

    // 使用post來call controller中的購買action
    $.post(buyUrl, arg, (data) => {
        console.log(data);
        alert("扣庫成功 - 已購買數量:" + String(data.deductionQuantity));
        window.location.reload();
    })
}

// [TODO]: 點擊預覽圖片時變更大圖
function onClickImage(imageUrl) {
    $("#__").attr("src", __); // [TODO]: 取代__帶入正確值
}

// 當購買數量有變化時更新購買總價格
function updateInput(unitPrice) {
    // 購買數量
    let buyNums = $("#buyQuantity").val();

    // 總價格
    let totalPrice = __ * __ // [TODO]: 取代__帶入正確值

    // 更新總價格
    $("#price").text("總價格 $" + String(totalPrice))
}

// 提交新的商品評價
function onReviewSubmit() {
    // [TODO]:評價者名稱
    let reviewer = __;

    // [TODO]:評價者信箱
    let reviewerEmail = __;

    // [TODO]:評價內容
    let reviewContent = __;

    // // 提交評價時所要call的action
    let commentUrl = $("#reviewPoster").data('request-url');
    console.log(commentUrl);

    // 將評價相關資訊包成一個物件
    let arg = {
        Reviewer: reviewer,
        ReviewerEmail: reviewerEmail,
        ReviewContent: reviewContent
    }

    // [TODO]:使用post來call controller中的評價action

}