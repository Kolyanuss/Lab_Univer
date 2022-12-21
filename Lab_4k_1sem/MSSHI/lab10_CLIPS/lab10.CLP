(deffacts drinkers
	(drinker Ivan Vasyl Petro)
	(drinker Petro Ivan Vasyl)
	(drinker Mykola Vasyl Ivan)
	(drinker Vasyl Petro Vasyl)
)
(defrule suspects
	(drinker ?name ?sus1 ?sus2)
		(not (suspect ?sus1))
	=>
		(assert(suspect ?sus1)))
		
(defrule who_is_right
	(drinker ?name ?sus1 ?sus2)
	(test (and (or (eq ?sus1 Petro) (eq ?sus2 Petro))
				(or (eq ?sus1 Vasyl) (eq ?sus2 Vasyl))
					))
	=>
		(assert (kaze-pravdu ?name))
		(printout t ?name "- kazhe pravdu" crlf))

(defrule who_is_lying
	(drinker ?name ?sus1 ?sus2)
		(not (kaze-pravdu ?name))
	=>
		(assert (breshe ?name))
		(printout t ?name "- brehlo" crlf))
	
	
(defrule who-not-stealer
	(drinker ?name ?sus1 ?sus2)
		(breshe ?name)
			(suspect ?sus1)
	=>
		(assert (ne-krav ?sus1)))
		
		
(defrule who-is_stealer
	(suspect ?name)
		(not (ne-krav ?name))
	=>
		(assert (KRADIY ?name))
		(printout t ?name " VKRAV KOROVU " crlf))