const express = require("express");
const router = express.Router();

// syllabus
const syllabusController = require('../controllers/syllabusController');

router.get('/', syllabusController.getAll);

router.get('/createform', syllabusController.createForm);
router.post('/', syllabusController.create);

router.get('/editform/:id', syllabusController.updateForm);
router.post('/edit/:id', syllabusController.update);

router.post('/delete/:id', syllabusController.delete);

module.exports = router;
