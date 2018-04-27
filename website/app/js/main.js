function saveToCart() {
	
}
(function() {
    var descriptions = {
        business: [
            'Beige Flats $32.99',
            'Black Flats $175.00',
            'Black Skirt $54.99',
            'Black Tip Flats $50.00',
            'Khaki Business Shirt $8.55',
            'Khaki Skirt $395.00',
            'Teal Business Shirt $20.00',
            'White Business Shirt $20.00',
            'White Skirt $20.00'
        ],
        casual: [
            'Black and white Vans $20.00',
            'Black Synchrony Tee $1050.00',
            'Burgundy Pants $32.99',
            'Jeans $395.00',
            'Khaki Pants $99.00',
            'Pink Synchrony Tee $33.99',
            'Pink Vans $68.00',
            'Plaid Vans $17.77',
            'Purple Tee $9.96'
        ],
        sport: [
            'Black Running Shoes $17.77',
            'Brown Running Shoes $9.96',
            'Grey Leggings $21.92',
            'Grey Tank Top $37.99',
            'Meshed Leggings $9.96',
            'Pink Leggings $29.99',
            'Pink Tank Top $79.95',
            'Teal Tank Top $20.00',
            'White Running Shoes $1050.00'
        ],
        maleBusiness: [
            'Black Dress Shirt $79.95',
            'Black Oxfords $49.00',
            'Black Slacks $89.00',
            'Brown Oxfords $17.99',
            'Casual Oxfords $64.95',
            'Grey Dress Shirt $64.95',
            'Grey Slacks $19.58',
            'Khaki Slacks $146.99',
            'Striped Dress Shirt $29.99'
        ],
        maleCasual: [
            'Black and white Vans $19.58',
            'Blue and white Vans $146.99',
            'Burgundy Pants $29.99',
            'Gradient Long Sleeve $33.99',
            'Jeans $39.99',
            'Khaki Pants $27.99',
            'Pink Obey Shirt $79.95',
            'Red and White Shirt $12.99',
            'Red and White Vans $79.95'
        ],
        maleSport: [
            'Black Gold Sneakers $12.99',
            'Black Running Shorts $9.97',
            'Black Synchrony Tank Top $8.00',
            'Blue Running Shorts $48.00',
            'Blue Sneakers $49.97',
            'Gold Sneakers $15.99',
            'Grey Tank Top $19.58',
            'Orange Synchrony Tank Top $146.99',
            'Red Running Shorts $29.99'
        ]
    };
    var checkoutBtn = document.querySelector( '#checkout' );
    var openCtrl = checkoutBtn.querySelector( '#checkout__button' ),
        closeCtrls = checkoutBtn.querySelectorAll( '.checkout__cancel' );
    openCtrl.addEventListener( 'click', function(ev) {
        ev.preventDefault();
        classie.add(checkoutBtn , 'checkout--active' );
    } );
    [].slice.call( closeCtrls ).forEach( function( ctrl ) {
        ctrl.addEventListener( 'click', function() {
            classie.remove( checkoutBtn, 'checkout--active' );
        } );
    } );
    var category = 'business';
    var description = descriptions[category];
    var basePath = './img/' + category;
    $('.dummy-grid__item>img').each(function(index){
        $(this).attr('src', basePath + '/' + index + '.png');
    });
    $('.dummy-grid__item>p').each(function(index){
        $(this).text(description[index]);
    });
    $('a.category').click(function(e) {
        e.preventDefault();
        var category = $(this).attr('data-category');
        var description = descriptions[category];
        var basePath = './img/' + category;
        $('.dummy-grid__item>img').each(function(index){
            $(this).attr('src', basePath + '/' + index + '.png');
        });
        $('.dummy-grid__item>p').each(function(index){
            $(this).text(description[index]);
        });
        return false;
    });
})();