const express = require("express");
const router = express.Router();

// students
const studentsController = require('../controllers/studentsController');

router.get('/', studentsController.getAll);

router.get('/createform', studentsController.createForm);
router.post('/', studentsController.create);

router.get('/editform/:id', studentsController.updateForm);
router.post('/edit/:id', studentsController.update);

router.post('/delete/:id', studentsController.delete);

module.exports = router;
