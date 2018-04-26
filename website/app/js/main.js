function saveToCart() {
	
}
(function() {
	// Firebase initialization
	// var fire_database = firebase.database();

    var descriptions = {
      sports: [
          'Tank Shirt $32.99',
		  'Marmot Tullus $175.00',
		  'Nike Women Dri-Fit $54.99',
		  'Nike Women Vapor Court $50.00',
		  'Hue Women Cotton-Blend Legging $8.55',
		  'Canada Goose Chilliwack Fur Trimmed $395.00'
	  ],
		winter: [
		    'Arctic Cat Women Warm $20.00',
			'Canada Weather Gear Men $1050.00',
			'Canada Goose Men Constable $395.00',
			'Arcteryx RHO Zip Neck - Women $99.00',
			'Rothco Solid Color Shemagh-Tactical $33.99',
			'Muk LUKS Boots Women NOLA Faux Fur Lined $68.00'
		],
		jeans: [
		    'Wrangler Men 5-Star $17.77',
			'Hudson Jeans Mens Slouchy $9.96',
			'Men Gettysburg Denim Jean $21.92',
			'Women Apt. 9 Embellished Bootcut $37.99',
			'Paper Denim & Cloth Men Skinny Fit $9.96',
			'Soho Jeans Curvy Bootcut Blue Tease $29.99'
		],
		bottoms: [
		    'Adidas Men Originals $79.95',
			'Men Patagonia Printed $49.00',
			'Zumba Fitness Women Outta-My-Space $89.00',
			'Arizona French Terry Jogger Pants $17.99',
			'Adidas Mens Originals Running Track $64.95',
			'Adidas Originals Adi Firebird Track $64.95'
		],
		dresses: [
		    'Womens Floral Print $19.58',
			'Parosh 3/4 Length Dress $146.99',
			'Zara Floral Print Dress $29.99',
			'Bonnie Jean Girls Pucker $33.99',
			'Global Elle Flower Print $39.99',
			'Zhishang Floral Print Dress $27.99'
		],
		sleepwear: [
		    'Jockey Womens Sleepwear $12.99',
			'Plus Size Chip N Dale Womens $9.97',
			'Womens Jockey Pajamas: Short Sleeve $8.00',
			'Womens 100% Cotton Knitted Comfort Fit $48.00',
			'Womens Pajama Pants - Xhilaration Dark Gray $9.97',
			'Hanes Womens Knit Notched Collar Top and Pants $15.99',
		]
	};
    var checkoutBtn = document.querySelector( '#checkout' );
    var openCtrl = checkoutBtn.querySelector( '#checkout__button' );
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

    var category = 'sports';
    var description = descriptions[category];
    var basePath = './img/' + category;
    $('.dummy-grid__item>img').each(function(index){
        $(this).attr('src', basePath + '/' + index + '.jpg');
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
		  $(this).attr('src', basePath + '/' + index + '.jpg');
      	});
        $('.dummy-grid__item>p').each(function(index){
            $(this).text(description[index]);
        });
      return false;
	});
})();