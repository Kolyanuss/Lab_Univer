(deffacts workers
	(spivrobitnyk Maxymovych 0 0 0)
	(spivrobitnyk Ghandabura 0.3 3 3000)
	(spivrobitnyk MisterX 100 0 999000)
	(spivrobitnyk Galochkin 30 1 20000)
	(spivrobitnyk Kovalchyk 25 2 19000)
)

(defrule premiya
	(spivrobitnyk ?surname ?work_years ?children_c ?salary)
	(test(or (>= ?work_years 5) (> ?children_c 2)))
		=> 
		(assert(premiya ?surname (* ?salary 0.2)))
		(printout t ?surname " got " (* ?salary 0.2) " prem" crlf))

(defrule if_all_got_premiya
	(forall (spivrobitnyk ?surname ?work_years ?children_c ?salary)
			(premiya ?surname))
	=>
	(printout t "all workers have got premiya!" crlf))
			
(defrule veteran_pratsy
	(spivrobitnyk ?surname ?work_years ?children_c ?salary)
	(test(> ?work_years 20))
		=> (printout t ?surname " veteran pratsi" crlf))