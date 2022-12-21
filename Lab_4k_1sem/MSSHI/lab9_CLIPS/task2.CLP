(deffacts Tovars
	(Tovar Bloody_battlegear_P85 650 10 2015 China)
	(Tovar MSI_Dragon 1000 20 2019 Ukraine)
	(Tovar ASUS_ROG_27d_RGB 3000 5 2005 Germany)
	(Tovar Lenovo_Ideapad_100 18000 3 2022 Ukraine)
	(Tovar Nvidia_RTX_3060 16000 6 2022 USA)
)

(defrule is_ucinka
	(Tovar ?name ?price ?count ?year ?country)
	(test(or (< ?year 2010) (< ?count 4)))
    => (assert(ucinka ?name (* ?price 0.15))))
	
(defrule is_nacinka
	(Tovar ?name ?price ?count ?year ?country)
	(test(and (eq ?year 2022) (neq ?country Ukraine)))
    => (assert(nacinka ?name (* ?price 0.07))))

(defrule is_Ukraine
	(Tovar ?name ?price ?count ?year ?country)
	(test(eq ?country Ukraine))
    => 
	(printout t "Vitchuznyaniy tovar: " ?name crlf))