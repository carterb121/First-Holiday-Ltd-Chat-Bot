USE HolidayDestinations;
GO

DROP TABLE IF EXISTS dbo.Destinations

CREATE TABLE Destinations (
	Id int,
	Name varchar(255) NOT NULL,
	Description varchar(max) NOT NULL,
	HolidayType varchar(255) NOT NULL,
	Country varchar(255) NOT NULL,
	Cost decimal NOT NULL,
	SuitableForSolo bit NOT NULL,
	SuitableForCouple bit NOT NULL,
	SuitableForFamily bit NOT NULL,
	SuitableForLargeParty bit NOT NULL,
	Rating decimal NOT NULL,
	PRIMARY KEY (Id)
);

INSERT INTO [dbo].[Destinations](
	Id,
	Name,
	Description,
	HolidayType,
	Country,
	Cost,
	SuitableForSolo,
	SuitableForCouple,
	SuitableForFamily,
	SuitableForLargeParty,
	Rating
)
VALUES
	(1,
	'Everest Base Camp Trek',
	'Taking us to the most iconic base camp of all at the foot of the greatest mountain in the world, Mount Everest (8848m)',
	'adventure',
	'Nepal',
	2950,
	1,
	1,
	0,
	0,
	4.7),

	(2,
	'Slovenia Mixed Activity',
	'An action packed week! Try whitewater rafting, canyoning and mountain biking or ride one of the longest zip lines in Europe!',
	'adventure',
	'Slovenia',
	1400,
	1,
	1,
	0,
	1,
	3.8),

	(3,
	'Family Lycian Activity Week',
	'The endless coastline, canyons and rivers of southern Turkey are the playground for adventures on land and sea.',
	'adventure',
	'Turkey',
	950,
	0,
	0,
	1,
	0,
	4.1),

	(4,
	'Tatra Winter Family Week',
	'A snow-laden landscape is always a wonderful sight in the mountains. For some it means heading to the slopes, for others it means strapping on the snowshoes or harnessing the dogs. There are so many different options it can be hard to choose.',
	'adventure',
	'Slovakia',
	630,
	0,
	0,
	1,
	0,
	3.2),

	(5,
	'Atlantica Creta Paradise',
	'Atlantica Creta Paradise combines a family-friendly set-up with luxury standards. A long sand-and-shingle beach out the front gives families plenty of elbow room. And the village layout just adds to the really spacious feel.',
	'beach',
	'Greece',
	484.60,
	0,
	0,
	1,
	0,
	4.4),

	(6,
	'Atlantica Oasis Hotel',
	'The Atlantica Oasis Hotel is in a great location for exploring, while offering up everything you could need for days spent relaxing at base. You�ve got a hotel-run kids� club and a children�s pool with a pirate ship, fountains and slides. But then there�s also an adults-only bar, a quiet pool reserved for grown-ups and a tranquil spa.',
	'beach',
	'Cyprus',
	471,
	0,
	0,
	1,
	0,
	4.0),

	(7,
	'Coral California',
	'This adults-only hotel gives you the best of both worlds. It�s library-quiet during the day around the pool. After dark, you can stroll 15 minutes to the neon-lit bars and discos of Veronica'+'s Strip � the resort�s main area for clubbing.',
	'beach',
	'Tenerife',
	280,
	1,
	1,
	0,
	0,
	3.1),

	(8,
	'Hotel Club Siroco',
	'Welcome to an idyllic Lanzarote hotel centred around two pools, where relaxation is at the fore. With so much space to spread out, a great range of facilities and a fab setting in Costa Teguise, it nails excellent value.',
	'beach',
	'Lanzarote',
	309,
	1,
	1,
	0,
	0,
	3.6),

	(9,
	'Tzante Hotel',
	'With its prime position on Laganas'+' nightclub-studded strip, the Tzante Hotel puts guests right in the thick of things.',
	'beach',
	'Zante',
	295,
	1,
	1,
	0,
	1,
	1.8),

	(10,
	'Odysseus',
	'The centre of Kavos is less than a minute�s walk away, so you can practically roll out of bed and onto the strip. The beach is only a few steps further, which means it�s easy to flit between pool and sea.',
	'beach',
	'Corfu',
	216,
	1,
	1,
	0,
	1,
	2.1),

	(11,
	'Atlantica Dreams',
	'With Bali beds on the beach, an adults-only restaurant and bar, and a children�s splash park, the Atlantica Dreams Resort and Spa brings luxury living to an under-the-radar corner of Rhodes.',
	'beach',
	'Rhodes',
	715,
	1,
	1,
	1,
	0,
	4.9),

	(12,
	'New York City Break',
	'Broadway, Central Park, The Empire State Building, Fifth Avenue � they�re all within striking distance of the Hotel Riu Plaza New York Times Square.',
	'city',
	'USA',
	671,
	1,
	1,
	1,
	0,
	3.1),

	(13,
	'Dubai City Break',
	'You�ll find this place on the Deira Islands, a quiet manmade area on the outskirts of Dubai�s city centre. You won�t be far from the action, though � a souk and a bustling spice market will be 20 minutes� drive away.',
	'city',
	'United Arab Emirates',
	724,
	1,
	1,
	1,
	0,
	4.7),

	(14,
	'Amsterdam City Break',
	'Made up of shimmering canals interlinked with white drawbridges, you�ll find beauty in the townhouses and open green spaces on an Amsterdam city break. Soak up the atmosphere in the lively squares and stack up the pancakes in a cosy caf�. It�s a glowing city all lit up at night too.',
	'city',
	'The Netherlands',
	375,
	1,
	1,
	1,
	1,
	3.8),

	(15,
	'Canary Islands',
	'In summer 2018, we welcomed Marella Explorer to the fleet. The ship stepped up to the plate, with a bumper batch of 10 restaurants and 10 bars.',
	'cruise',
	'Cruise',
	828,
	1,
	1,
	0,
	1,
	4.1),

	(16,
	'Aegean Delights',
	'Marella Discovery 2 is the sister ship to Marella Discovery, which means it shares most of the same top-notch facilities. These include an outdoor cinema, a rock climbing wall and a minigolf course. Not to mention the two pools � one indoor and one outdoor � plus, seven restaurants and a spa.',
	'cruise',
	'Cruise',
	744,
	1,
	1,
	1,
	1,
	4.4),

	(17,
	'Paradise Islands (Caribbean)',
	'Marella Explorer 2 is our newest ship in the fleet. It�s adults only and flaunts a range of exciting facilities, from a Champneys Spa to a chic bar-club-casino space. You�ve got nine bars and nine restaurants on this ship, too.',
	'cruise',
	'Cruise',
	1841,
	1,
	1,
	1,
	1,
	4.5)