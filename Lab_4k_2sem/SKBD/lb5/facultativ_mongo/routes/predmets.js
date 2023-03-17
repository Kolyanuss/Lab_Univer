const express = require("express");
const router = express.Router();

// predmets
const predmetsController = require('../controllers/predmetsController');

router.get('/', predmetsController.getAll);
router.get('/:id', predmetsController.getById);

router.get('/create', predmetsController.createForm);
router.post('/', predmetsController.create);

router.get('/edit/:id', predmetsController.updateForm);
router.put('/:id', predmetsController.update);

router.delete('/:id', predmetsController.delete);

module.exports = router;
