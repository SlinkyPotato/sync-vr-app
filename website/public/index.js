(function() {

var fbNames = {
        business: [
            'female_business_!beige_flats@',
            'female_business_!black_flats@',
            'female_business_!black_skirt@',
            'female_business_!black_tip_flats@',
            'female_business_!khaki_business_shirt@',
            'female_business_!khaki_skirt@',
            'female_business_!teal_business_shirt@',
            'female_business_!white_business_shirt@',
            'female_business_!white_skirt@'
        ],
        casual: [
            'female_casual_!black_and_white_vans@',
            'female_casual_!black_synchrony_tee@',
            'female_casual_!burgundy_pants@',
            'female_casual_!jeans@',
            'female_casual_!khaki_pants@',
            'female_casual_!pink_synchrony_tee@',
            'female_casual_!pink_vans@',
            'female_casual_!plaid_vans@',
            'female_casual_!purple_tee@'
        ],
        sport: [
            'female_sport_!black_running_shoes@',
            'female_sport_!brown_running_shoes@',
            'female_sport_!grey_leggings@',
            'female_sport_!grey_tank_top@',
            'female_sport_!meshed_leggings@',
            'female_sport_!pink_leggings@',
            'female_sport_!pink_tank_top@',
            'female_sport_!teal_tank_top@',
            'female_sport_!white_running_shoes@'
        ],
        maleBusiness: [
            'male_business_!black_dress_shirt@',
            'male_business_!black_oxfords@',
            'male_business_!black_slacks@',
            'male_business_!brown_oxfords@',
            'male_business_!casual_oxfords@',
            'male_business_!grey_dress_shirt@',
            'male_business_!grey_slacks@',
            'male_business_!khaki_slacks@',
            'male_business_!striped_dress_shirt@'
        ],
        maleCasual: [
            'male_casual_!black_and_white_vans@',
            'male_casual_!blue_and_white_vans@',
            'male_casual_!burgundy_pants@',
            'male_casual_!gradient_long_sleeve@',
            'male_casual_!jeans@',
            'male_casual_!khaki_pants@',
            'male_casual_!pink_obey_shirt@',
            'male_casual_!red_and_white_shirt@',
            'male_casual_!red_and_white_vans@'
        ],
        maleSport: [
            'male_sport_!black_gold_sneakers@',
            'male_sport_!black_running_shorts@',
            'male_sport_!black_synchrony_tank_top@',
            'male_sport_!blue_running_shorts@',
            'male_sport_!blue_sneakers@',
            'male_sport_!gold_sneakers@',
            'male_sport_!grey_tank_top@',
            'male_sport_!orange_synchrony_tank_top@',
            'male_sport_!red_running_shorts@'
        ]
    };

var descriptions = {
        business: [
            'Beige Flats',
            'Black Flats',
            'Black Skirt',
            'Black Tip Flats',
            'Khaki Business Shirt',
            'Khaki Skirt',
            'Teal Business Shirt',
            'White Business Shirt',
            'White Skirt'
        ],
        casual: [
            'Black and white Vans',
            'Black Synchrony Tee',
            'Burgundy Pants',
            'Jeans',
            'Khaki Pants',
            'Pink Synchrony Tee',
            'Pink Vans',
            'Plaid Vans',
            'Purple Tee'
        ],
        sport: [
            'Black Running Shoes',
            'Brown Running Shoe',
            'Grey Leggings',
            'Grey Tank Top',
            'Meshed Leggings',
            'Pink Leggings',
            'Pink Tank Top',
            'Teal Tank Top',
            'White Running Shoes'
        ],
        maleBusiness: [
            'Black Dress Shirt',
            'Black Oxfords',
            'Black Slacks',
            'Brown Oxfords',
            'Casual Oxfords',
            'Grey Dress Shirt',
            'Grey Slacks',
            'Khaki Slacks',
            'Striped Dress Shirt'
        ],
        maleCasual: [
            'Black and white Vans',
            'Blue and white Vans',
            'Burgundy Pants',
            'Gradient Long Sleeve',
            'Jeans',
            'Khaki Pants',
            'Pink Obey Shirt',
            'Red and White Shirt',
            'Red and White Vans'
        ],
        maleSport: [
            'Black Gold Sneakers',
            'Black Running Shorts',
            'Black Synchrony Tank Top',
            'Blue Running Shorts',
            'Blue Sneakers',
            'Gold Sneakers',
            'Grey Tank Top',
            'Orange Synchrony Tank Top',
            'Red Running Shorts'
        ]
    };
    var checkoutBtn = document.querySelector( '#checkout' );
    var openCtrl = checkoutBtn.querySelector( '#checkout__button' ),
        closeCtrls = checkoutBtn.querySelectorAll( '.checkout__cancel' );

    openCtrl.addEventListener( 'click', function(ev) {
        ev.preventDefault();
	classie.add(checkoutBtn , 'checkout--active' );
	updateCart();
	
    });

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
	var iname = fbNames[category];
	$(this).attr('id', iname[index]);
    });
    $('.dummy-grid__item>p').each(function(index){
	var price = '';
	var iname = fbNames[category];
	var fbprice = firebase.database().ref('products').child(iname[index]);
	var item = $(this);
	fbprice.once('value', function(snapshot){
		price += snapshot.val() && snapshot.val().price;
		item.text(description[index]+' $'+price);
	});
	
	
    });

    // Change the categories when a category button gets hit
    $('a.category').click(function(e) {
      e.preventDefault();
      var category = $(this).attr('data-category');
      var description = descriptions[category];
      var basePath = './img/' + category;
		$('.dummy-grid__item>img').each(function(index){
		  $(this).attr('src', basePath + '/' + index + '.png');
		var iname = fbNames[category];
		$(this).attr('id', iname[index]);
		$(this).attr('index', index);
      	});
        $('.dummy-grid__item>p').each(function(index){
            var price = '';
		var iname = fbNames[category];
		var fbprice = firebase.database().ref('products').child(iname[index]);
		var item = $(this);
		fbprice.once('value', function(snapshot){
			price += snapshot.val() && snapshot.val().price;
			item.text(description[index]+' $'+price);
		});
        });
      return false;
	});

	$('img.img-item').click(function(e) {
		e.preventDefault();
		var element = e.target;
		var newPostKey = firebase.database().ref('carts/user1_cart').child('product_list').push().key;
		var updates = {};
		var data = { id: element.id, quantity: 1};
  		updates['/carts/user1_cart/product_list/' + newPostKey] = data;
		firebase.database().ref().update(updates);
		firebase.database().ref('/products/'+element.id).once('value').then(function(snapshot) {
			document.getElementById('total').textContent= snapshot.val() && snapshot.val().price;
			firebase.database().ref('/carts/user1_cart/product_list/1').once('value').then(function(snapshot) {
				var tot = parseInt(snapshot.val() && snapshot.val().quantity);
				var price = parseInt(document.getElementById('total').textContent);
				tot+=price;
				firebase.database().ref('carts/user1_cart/product_list/1').update({id: 'total', quantity: tot});
				document.getElementById('total').textContent= tot;
			});
		});
		updateCart();
		return false;
	});
})();
function male()
{
	firebase.database().ref('users/user1').update({gender: 'male'});
	document.getElementById("curGender").innerHTML = "Current Gender: Male";
}
function female()
{
	firebase.database().ref('users/user1').update({gender: 'female'});
	document.getElementById("curGender").innerHTML = "Current Gender: Female";
}
function checkOut()
{
	firebase.database().ref('carts/user1_cart/product_list').remove();
	firebase.database().ref('carts/user1_cart/product_list').set([{id: 'do_not_delete', quantity: '0'},{id: 'total', quantity: 0}]);
	window.location.replace("thankyou.html");
}
function updateCart()
{
	var cart = document.getElementById("cart");
	while (cart.firstChild) {
    		cart.removeChild(cart.firstChild);
		}
	firebase.database().ref('/carts/user1_cart/product_list').once('value').then(function(snapshot) {
		var products = snapshot.val() || [];
        	var content = '';
		var cart = document.getElementById("cart");
		while (cart.firstChild) {
    			cart.removeChild(cart.firstChild);
		}
        	snapshot.forEach(function(data){
            	var id = data.val().id;
		if(id =='do_not_delete') return;
		if(id =='total')
		{
			document.getElementById('total').textContent= data.val().quantity;
			return;
		}
            	var quantity = data.val().quantity;
		var fbprice = firebase.database().ref('products').child(id);
		var item = $(this);
		fbprice.once('value', function(snapshot){
			var price = snapshot.val() && snapshot.val().price;
			var name = snapshot.val() && snapshot.val().name;
			content += '<tr>';
            		content += '<td>' + name + '</td>';
			content += '<td>' + price + '</td>';
			content += '</tr>';
			document.getElementById("cart").insertAdjacentHTML('beforeend',content);
			content ='';
		});
        });
});
}

